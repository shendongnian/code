    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                const int ARRAY_SIZE = 10000;
                var array = Enumerable.Range(0, ARRAY_SIZE).Select(x => x).ToArray();
                Stopwatch sw = new Stopwatch();
                const int COUNT = 100000;
                for (int i = 0; i < 8; ++i)
                {
                    sw.Restart();
                    for (int j = 0; j < COUNT; ++j)
                        array.TakeLastViaArrayCopy(ARRAY_SIZE/2);
                    Console.WriteLine("TakeLastViaArrayCopy took " + sw.Elapsed);
                    sw.Restart();
                    for (int j = 0; j < COUNT; ++j)
                        array.TakeLastViaBlockCopy(ARRAY_SIZE/2);
                    Console.WriteLine("TakeLastViaBlockCopy took " + sw.Elapsed);
                    Console.WriteLine();
                }
            }
            private static void Main()
            {
                new Program().run();
            }
        }
        public static class ArrayExt
        {
            public static T[] TakeLastViaBlockCopy<T>(this T[] inputArray, int count) where T: struct
            {
                count = Math.Min(count, inputArray.Length);
                int size = Marshal.SizeOf(typeof(T));
                T[] result = new T[count];
                Buffer.BlockCopy(inputArray, (inputArray.Length-count)*size, result, 0, count*size);
            
                return result;
            }
            public static T[] TakeLastViaArrayCopy<T>(this T[] inputArray, int count) where T: struct
            {
                count = Math.Min(count, inputArray.Length);
                T[] result = new T[count];
                Array.Copy(inputArray, inputArray.Length-count, result, 0, count);
                return result;
            }
        }
    }
