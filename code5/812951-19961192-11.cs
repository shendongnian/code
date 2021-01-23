        static void Main()
        {
            Console.WriteLine("Begin");
            var result = BlockingMethod("Hi!");
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
        static bool BlockingMethod(string someText)
        {
            Thread.Sleep(2000);
            return someText.Contains("SomeOtherText");
        }
