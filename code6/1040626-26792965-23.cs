    using System;
    using System.Linq;
    
    namespace ShuffleAndTakeUnique
    {
        public class Program
        {
            static Random _random = new Random();
    
            static void Main(string[] args)
            {
                int[] array = { 3, 4, 6, 2, 5, 11, 12, 20, 19, 18, 17, 15, 16, 1, 7, 8, 9, 10, 13, 14 };
                var values = Shuffle<int>(array).Distinct().Take(3).ToArray();
    
                foreach(var val in values)
                {
                    Console.WriteLine(val);
                }
            }
    
            public static T[] Shuffle<T>(T[] source)
            {
                T[] array = new T[source.Length];
                Array.Copy(source, array, source.Length);
                var random = _random;
    
                for (int i = array.Length; i > 1; i--)
                {
                    int j = random.Next(i);
                    T tmp = array[j];
                    array[j] = array[i - 1];
                    array[i - 1] = tmp;
                }
    
                return array;
            }
        }
    }
