    public static Dictionary<T, U> DictionaryFromArrays<T,U>(T[] keys, U[] values)
    {
         var dictionary = new Dictionary<T, U>();
         if (keys.Length == values.Length)
         {
             for (int i = 0; i < keys.Length; i++)
             {
                 dictionary.Add(keys[i], values[i]);
             }
         }
         else
         {
             /* throw exception */
         }
   
         return dictionary;
    }
