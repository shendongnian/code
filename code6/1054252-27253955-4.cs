    public static class Ensure
    {
        public static void NotNull(params object[] objects)
        {
           if (objects.Any(x => null == x)
              throw new ArgumentNullException();
        }
    }
