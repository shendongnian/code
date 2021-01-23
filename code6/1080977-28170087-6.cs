    static void Main(string[] args)
    {
        // Try with .ToList() and .ToArray()
        var range1 = Enumerable.Range(1, 1000);
        var range2 = Enumerable.Range(1, 1000);
    
        int numberOfSums = 100000;
        int numberOfTests = 3;
    
        for (int i = 0; i < numberOfTests; i++)
        {
            SumBenchmark(range1, LinqExtension.Sum1, numberOfSums, "Sum1");
        }
    
        for (int i = 0; i < numberOfTests; i++)
        {
            // Also try with range1
            SumBenchmark(range2, LinqExtension.Sum2, numberOfSums, "Sum2");
        }
    
        Console.ReadKey();
    }
    
    static void SumBenchmark(IEnumerable<int> numbers, Func<IEnumerable<int>, int> sum, int numberOfSums, string name)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < numberOfSums; i++)
        {
            long result = sum(numbers);
        }
        sw.Stop();
        Console.WriteLine("{2}: {0} ticks in {1} ms ", sw.ElapsedTicks.ToString(), sw.ElapsedMilliseconds.ToString(), name);
    }
