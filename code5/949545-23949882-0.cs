    public static class Extension
    {
        public static bool HasValue<T>(this self) where T : class
        {
            return self != null;
        }
    }
