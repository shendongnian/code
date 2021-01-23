    public static class StringExtensions
    {
        public static string RepeatString(this string input, int count)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder(input.Length * count);
            for(int i = 0; i < count; ++i)
            {
                builder.Append(input);
            }
            return builder.ToString();
        }
    }
