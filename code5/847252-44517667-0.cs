    public static class StringExtension
    {
        /// <summary>
        /// Returns first line in a string or entire string if no linebreaks are included
        /// </summary>
        /// <param name="str">String value</param>
        /// <returns>Returns first line in the string</returns>
        public static string FirstLine(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            var newLinePos = str.IndexOf(Environment.NewLine, StringComparison.CurrentCulture);
            return newLinePos > 0 ? str.Substring(0, newLinePos) : str;
        }
    }
