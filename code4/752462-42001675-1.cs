    public static class Extension
    {
          public static bool HasDuplicate(
              this IEnumerable<T> source,
              out T firstDuplicate)
          {
              if (sequence == null)
              {
                  throw ArgumentNullException(nameof(source));
              }
              var checkBuffer = new HashSet<T>();
              foreach(firstDuplicate in source)
              {
                 if (!checkBuffer.Add(item))
                 {
                     return true;
                 }
              }
              firstDuplicate = default(T);
              return false;
          }
    }
