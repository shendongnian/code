    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication4
    {
        public static class Program
        {
            private static void Main()
            {
                var array = new [,]
                {
                    {0.1, 0.2, 0.3, 0.4, 0.5},
                    {1.1, 1.2, 1.3, 1.4, 1.5},
                    {2.1, 2.2, 2.3, 2.4, 2.5},
                    {3.1, 3.2, 3.3, 3.4, 3.5},
                };
                var row = array.GetRow(2);
                // This prints 2.1, 2.2, 2.3, 2.4, 2.5
                Console.WriteLine(string.Join(", ", row.Select(element => element.ToString())));
            }
        }
        public static class ArrayExt
        {
            public static T[] GetRow<T>(this T[,] array, int row)
            {
                if (!typeof(T).IsPrimitive)
                    throw new InvalidOperationException("Not supported for managed types.");
                if (array == null)
                    throw new ArgumentNullException("array");
                int cols = array.GetUpperBound(1) + 1;
                T[] result = new T[cols];
                int size = typeof(T) == typeof(bool) ? 1 : Marshal.SizeOf<T>();
                Buffer.BlockCopy(array, row*cols*size, result, 0, cols*size);
                return result;
            }
       }
    }
