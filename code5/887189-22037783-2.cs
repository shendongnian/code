    public static List<object> Mesh<T1, T2>(IEnumerable<T1> s1, IEnumerable<T2> s2)
    {
         T1[] array1 = s1.ToArray();
         T2[] array2 = s2.ToArray();
         int length1 = array1.Length;
         int length2 = array2.Length;
         int maxLength = Math.Max(length1, length2);
         List<object> result = new List<object>();
         for (int i = 0; i < maxLength; i++)
         {
              result.Add(array1[i % length1]);
              result.Add(array2[i % length2]);
         }
         return result.
    }
