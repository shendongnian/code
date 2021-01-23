    public static class StringExtension
    {
        public static bool ContainsInt(this string str, int value)
        {
            return str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .Contains(value);
        }
    }
