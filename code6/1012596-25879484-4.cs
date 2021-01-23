    public static class StringHelper
    {
        public static string Crop(this string text, int maxLength)
        {
            if (text == null) return string.Empty;
    
            if (text.Length < maxLength) return text;
    
            return text.Substring(0, maxLength);
        }
    }
