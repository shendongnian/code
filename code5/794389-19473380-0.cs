    public static class InterlockedEx
    {
      public static T Change<T>(ref T destination, Func<T, T> operation) where T : class
      {
        T original, value;
        do
        {
            original = destination;
            value = operation(original);
        }
        while (Interlocked.CompareExchange(ref destination, value, original) != original);
        return original;
      }
    }
