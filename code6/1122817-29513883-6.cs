    public static class StringExtensions
    {
        public static string ToEncodedASCII(this string input, Encoding sourceEncoding)
        {
            return StringUtilities.HtmlEncode(input, sourceEncoding, Encoding.ASCII);
        }
        public static string ToEncodedASCII(this string input)
        {
            return StringUtilities.HtmlEncode(input, Encoding.Unicode, Encoding.ASCII);
        }
    }
