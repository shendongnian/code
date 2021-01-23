    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "put the first value";
            string str2 = "put the second value";
            CompareTwoStringsWithStopWatch(str1, str2); //Print the results.
        }
        private static void CompareTwoStringsWithStopWatch(string str1, string str2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 99999999; i++)
            {
                if (str1.Length == str2.Length && str1 == str2)
                {
                    SomeOperation();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("{0}. Time: {1}", "Result for: str1.Length == str2.Length && str1 == str2", stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 99999999; i++)
            {
                if (str1 == str2)
                {
                    SomeOperation();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("{0}. Time: {1}", "Result for: str1 == str2", stopwatch.Elapsed);
        }
        private static int SomeOperation()
        {
            var value = 500;
            value += 5;
            return value - 300;
        }
    }
