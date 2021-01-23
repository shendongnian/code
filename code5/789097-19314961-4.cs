    namespace N
    {
      static class MyExtensions
      {
        public static void MutateAll<T>(this T[] array, Func<T, T> selector)
        {
          for (int i = 0; i < array.Length; ++i)
            array[i] = selector(array[i]);
        }
      }
    }
