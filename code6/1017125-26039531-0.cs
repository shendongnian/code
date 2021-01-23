    public static class Extensions
    {
        public static bool Match(this string value, String query)
        {
            return Regex.IsMatch(value, query);
        }
        public static void Out<t>(this t value)
        {
            Console.WriteLine(value);
        }
    }
