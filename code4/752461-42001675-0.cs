    public static class Extension
    {
          public static bool HasDuplicate(this IEnumerable<T> source)
          {
              if (sequence == null)
              {
                  throw ArgumentNullException(nameof(source));
              }
              var checkBuffer = new HashSet<T>();
              foreach(var item in source)
              {
                 if (checkBuffer.Contains(item))
                 {
                     return true;
                 }
                 checkBuffer.Add(item);
              }
              return false;
          }
    }
