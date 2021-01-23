    public static class Extensions
    {
        public static string Remove(this string source, int start, int count, out char letter)
        {
            letter = source[start];
            return source.Remove(start, count);
        }
    }
