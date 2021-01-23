    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication4
    {
        public sealed class Index
        {
            public Index(int row, int col)
            {
                Row = row;
                Col = col;
            }
            public readonly int Row;
            public readonly int Col;
        }
        public static class Program
        {
            private static void Main()
            {
                int [,] p = new int[5, 5];
                for (int i = 0, n = 1; i < 5; ++i)
                    for (int j = 0; j < 5; ++j, ++n)
                        p[i, j] = n;
                // This is the bit you will use in your program.
                // Replace the Console.WriteLine() with your custom code
                // that uses p[index.Row, index.Col]
                int maxIndex = p.GetUpperBound(1);
                foreach (var index in DiagonalIndices(maxIndex))
                    Console.Write(p[index.Row, index.Col] + " ");
                Console.WriteLine();
            }
            public static IEnumerable<Index> DiagonalIndices(int maxIndex)
            {
                for (int i = 0; i <= maxIndex; ++i)
                    for (int j = 0; j <= i; ++j)
                        yield return new Index(maxIndex-i+j, j);
                for (int i = 0; i < maxIndex; ++i)
                    for (int j = 0; j < maxIndex-i; ++j)
                        yield return new Index(j, i+j+1);
            }
        }
    }
