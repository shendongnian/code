    public static class Extension
    {
          public static bool HasDuplicate<T>(
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
                 if (!checkBuffer.Add(firstDuplicate))
                 {
                     return true;
                 }
              }
              firstDuplicate = default(T);
              return false;
          }
    }
