    public static class MyExtensions
    {
        public static bool ContainsAny(this string source, ICollection<string> words)
        {
            foreach (var word in words)
            {
                if (source.Contains(word)) return true;
            }
            return false;
        }
    }
