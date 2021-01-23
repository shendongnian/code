    namespace N
    {
      delegate void ActionWithRef<T>(ref T obj);
      static class MyExtensions
      {
        public static void ForEachWithRef<T>(this T[] array, ActionWithRef<T> action)
        {
          for (int i = 0; i < array.Length; ++i)
            action(ref array[i]);
        }
      }
    }
