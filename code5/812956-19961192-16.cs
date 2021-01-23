        static async Task MainAsync()
        {
            Console.WriteLine("Begin");
            bool result = await Task.Run(() => BlockingMethod("Hi!"));
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
