        static async Task Main()
        {
            Console.WriteLine("Begin");
            bool result = true; 
            await Task.Run(() => result = BlockingMethod("Hi!"));
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
