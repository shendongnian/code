    public static void ForEachWithNullCheck<T>(this List<T> list, Action<T> action)
    {
      if (list == null)
      {
        // silently do nothing...
      }
      else
      {
        list.ForEach(action); 
      }
    }
