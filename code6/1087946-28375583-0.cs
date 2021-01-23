    public static class Helpers
    {
        public static List<string> ToStringList<T>(this List<T> self)
        {
            return self.Select(t => t.ToString()).ToList();
        }
    }
