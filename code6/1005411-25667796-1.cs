    static class MyListExtenstions
    {
      static IList AddToList<T>(this IList list, T item)
      {
        list.Add(item);
        return list;
      }
    }
