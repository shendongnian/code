    public static List<object> Mesh<T1, T2>(IEnumerable<T1> s1, IEnumerable<T2> s2)
    {
         T1[] array1 = s1.ToArray();
         T2[] array2 = s2.ToArray();
         List<object> result = new List<object>();
         for (int i = 0; i < Math.Max(array1.Length, array2.Length); i++)
         {
              result.Add(array1[i % array1.Length]);
              result.Add(array2[i % array2.Length]);
         }
         return result.
    }
