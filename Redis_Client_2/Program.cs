using System;
using StackExchange.Redis;

namespace Redis_Client_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ConfigurationOptions();
            options.EndPoints.Add("localhost", 6379);

            var redis = ConnectionMultiplexer.Connect(options);
            var db = redis.GetDatabase(4);

            Console.WriteLine("Чтобы продолжить нажмите любую клавишу, для выхода нажмите ESC");
            var consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                Console.Write("Введите 1 ключ: ");
                var key1 = Console.ReadLine();
                Console.Write("Введите 2 ключ: ");
                var key2 = Console.ReadLine();

                Console.WriteLine($"Результат {(int)db.StringGet(key1) * (int)db.StringGet(key2)}");

                Console.WriteLine("Чтобы продолжить нажмите любую клавишу, для выхода нажмите ESC");
                consoleKey = Console.ReadKey();
            }
        }
    }
}