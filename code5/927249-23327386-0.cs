    using System;
    using System.Collections.Generic;
    namespace konsol
    {
    class Program
    {
        private static List<List<int>> combinations = new List<List<int>>();
        private static void Main(string[] args)
        {
            int length = 4
            Generate(length , 10, 0, 1, 0, new int[length]);
           
            foreach (var varibles in combinations)
            {
                Console.WriteLine(String.Join(",", variables));
            }
            Console.ReadKey();
        }
        private static void Generate(int length, int target, int k, int last, int sum, int[] a)
        {
            if (k == length- 1)
            {
                a[k] = target - sum;
                combinations.Add(new List<int>(a));
            }
            else
            {
                for (int i = last; i < target - sum - i + 1; i++)
                {
                    a[k] = i;
                    Generate(length, target, k + 1, i, sum + i, a);
                }
            }
        }
    }
    }
