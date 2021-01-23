    public static class StringExtensions
    {
        public static string Slice(this string s, int startIndex, int endIndex)
        {
	    int length = endIndex - startIndex;               // Calculate length
	    return s.Substring(startIndex, length); // Return Substring of length
        }
    }
