    public static class ObjectExtensions
    {
        public static bool TryCast<T>(this object from, out T to) where T : class
        {
            to = from as T;
            return to != null;
        }
    }
