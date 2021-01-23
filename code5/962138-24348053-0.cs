    public static class Extensions
    {
        public static string ToAlphaNum(this string input)
        {
            return string.Concat(input.Where(char.IsLetterOrDigit));
        }
    }
