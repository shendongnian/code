    public static class StringEx
    {
        public static string[] Split(this string s, char sep, int minLength)
        {
            return s.Split(sep)
                    .Where(s => s.Length >= minLength)
                    .ToArray();
        }
    }
