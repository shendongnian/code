    public static class ListExt
    {
        public static bool IsNullOrEmpty<T>(this List<T> self)
        {
            return (self == null) || (self.Count == 0);
        }
    }
