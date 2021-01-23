        static async void Main()
        {
            Console.WriteLine("Begin");
            var result = BlockingMethod("Hi!");
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
