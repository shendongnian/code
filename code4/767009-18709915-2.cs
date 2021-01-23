    public static class Bar {
      public static IEnumerable<T> EnumerateAtoms<T> (this T input) where T : enum {
        foreach(T value in Enum.GetValues(typeof(T))) {
          if((input&val) != 0x00) {
            yield return value;
          }
        }
      }
    }
