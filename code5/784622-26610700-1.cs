    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Solution
    {
      private static void Main(String[] args)
      {
        var array = new int[] { 1, 2, 3, 4 };
        Dictionary<string, int> results = new Dictionary<string, int>();
        for (int i = 0; i < 500000; i++)
        {
          var a = array.ToArray();
          Shuffller.Shuffle(a);
          var data = string.Join(" ", a);
          if (results.ContainsKey(data))
          {
            results[data]++;
          }
          else
          {
            results.Add(data, 1);
          }
        }
    
        foreach (var item in results.OrderBy(e => e.Key))
        {
          Console.WriteLine("{0}  => {1}", item.Key, item.Value);
        }
        Console.ReadKey();
      }
    
      public class Shuffller
      {
        private static Random random = new Random();
        /// <summary>
        /// * Rearranges an array of objects in uniformly random order
        ///  (under the assumption that Random generates independent
        ///  and uniformly distributed numbers).          
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">the array to be shuffled     </param>
        public static void Shuffle<T>(T[] a)
        {
          int N = a.Length;
          for (int i = 0; i < N; i++)
          {
            // choose index uniformly in [i, N-1]        
            int r = i + random.Next(0, N - i);
            T swap = a[r];
            a[r] = a[i];
            a[i] = swap;
          }
        }
     
      }  
      }
     
