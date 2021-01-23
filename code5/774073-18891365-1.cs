    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                List<int> list = new List<int> {1};
                test(list); // Caller can just pass list, although method accepts IReadOnlyList<int>
                int[] array = new int[10];
                test(array); // Works with arrays too.
            }
            void test(IReadOnlyList<int> data)
            {
                Console.WriteLine(data.Count);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
