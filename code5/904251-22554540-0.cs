    using System;
    namespace ConsoleApp1
    {
        public class ArrayWrapper<T>
        {
            public T[,] Array;
            public static implicit operator ArrayWrapper<T>(T[,] array)
            {
                return new ArrayWrapper<T> {Array = array};
            }
        }
        sealed class Program
        {
            void run()
            {
                string[,] op1 = new string[9, 9];
                string[,] op2 = new string[9, 9];
                string[,] op3 = new string[9, 9];
                IterateArrays<string>(processArray, op1, op2, op3);
            }
            static void processArray(string[,] array, int index)
            {
                Console.WriteLine("Processing array with index " + index);
            }
            public static void IterateArrays<T>(Action<T[,], int> action, params ArrayWrapper<T>[] arrays)
            {
                for (int i = 0; i < arrays.Length; ++i)
                    action(arrays[i].Array, i);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
