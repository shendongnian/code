        static async Task Main()
        {
            Console.WriteLine("Begin");
            await Task.Run(() => BlockingMethod("Hi!"));
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
