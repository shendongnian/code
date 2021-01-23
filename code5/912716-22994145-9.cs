    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    class Test
    {    
        const int Size = 100000000;
        const int Iterations = 3;
        
        static void Main()
        {
            int[] input = new int[Size];
            // Use the same seed for repeatability
            var rng = new Random(0);
            for (int i = 0; i < Size; i++)
            {
                input[i] = rng.Next(Size);
            }
            
            // Switch to PopulateArray to change which method is tested
            Func<int[], int, TimeSpan> test = PopulateDictionary;
            
            for (int buckets = 10; buckets <= Size; buckets *= 10)
            {
                TimeSpan total = TimeSpan.Zero;
                for (int i = 0; i < Iterations; i++)
                {
                    // Switch which line is commented to change the test
                    // total += PopulateDictionary(input, buckets);
                    total += PopulateArray(input, buckets);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                Console.WriteLine("{0,9}: {1,7}ms", buckets, (long) total.TotalMilliseconds);
            }
        }
        
        static TimeSpan PopulateDictionary(int[] input, int buckets)
        {
            int divisor = input.Length / buckets;
            var dictionary = new Dictionary<int, int>(buckets);
            var stopwatch = Stopwatch.StartNew();
            foreach (var item in input)
            {
                int key = item / divisor;
                int count;
                dictionary.TryGetValue(key, out count);
                count++;
                dictionary[key] = count;
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    
        static TimeSpan PopulateArray(int[] input, int buckets)
        {
            int[] output = new int[buckets];
            int divisor = input.Length / buckets;
            var stopwatch = Stopwatch.StartNew();
            foreach (var item in input)
            {
                int key = item / divisor;
                output[key]++;
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
