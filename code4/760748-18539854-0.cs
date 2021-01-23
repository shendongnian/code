    public static class MyExtension
    {
        public static bool In(this string c, params string[] items)
        {
             return items.Contains(c);
             //OR //return items.Any(r => r == c);
        }
    }
