    using System;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            [STAThread]
            private static void Main()
            {
                int[][] array1 =
                { 
                    new [] {1, 22, 3, 44, 5, 66},
                    new [] {11, 22, 33, 44, 55, 66},
                    new [] {1, 2, 3, 4, 5, 6},
                    new [] {1, 66, 3, 4, 5, 6} // This one has the target items out of order.
                };
                int[] array2 = {1, 2, 3, 5, 66};
                // Extract the targets like this; it avoids making a copy
                // of array2 which occurs if you use IEnumerable.Reverse().
                int[] targets = {array2[array2.Length - 2], array2[array2.Length - 1]};
                // Count the number of times that each subarray in array1 includes
                // all the items in targets:
                int count = array1.Count(array => array.Intersect(targets).Count() == targets.Length);
                Console.WriteLine(count);
            }
        }
    }
