    using System;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                int[,] example =
                {
                    { 1,  2,  3,  4}, 
                    { 5,  6,  7,  8}, 
                    { 9, 10, 11, 12},
                    {13, 14, 15, 16},
                    {17, 18, 19, 20},
                };
                int sourceColumns = example.GetUpperBound(0);
                int[] row1 = new int[sourceColumns];
                int requiredRow = 3;
                int sourceOffset = requiredRow * sourceColumns * sizeof(int);
                int sourceWidthBytes = sourceColumns*sizeof (int);
                Buffer.BlockCopy(example, sourceOffset, row1, 0, sourceWidthBytes);
                Console.WriteLine(string.Join(", ", row1));
                // If you really must have a List<int>
                // (but this will likely make it much slower than just
                // adding items to the list on an element-by-element basis):
                var list = new List<int>(row1);
                // Do something with list.
            }
        }
    }
