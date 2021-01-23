    HashSet<string> dict = new HashSet<string>();
    
    foreach(string str in arbitraryStringCollection)
    {
        dict.DoOnce(str, ProcessString);
    }
    // Re-usable extension method)
    public static class ExtensionMethods
    {
        public static void DoOnce<T>(this ISet<T> set, T value, Action<T> action)
        {
            if (!set.Contains(value))
            {
                action(value);
                set.Add(value);
            }
        }
    }
