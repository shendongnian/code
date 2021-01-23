    public static string TruncateMiddle(this string value, int lengthExpected, string separator = "...")
        {
            if (value.Length <= lengthExpected) return value;
            decimal sepLen = separator.Length;
            decimal charsToShow = lengthExpected - sepLen;
            decimal frontChars = Math.Ceiling(charsToShow / 2);
            decimal backChars = Math.Floor(charsToShow / 2);
            return value.Substring(0, (int)frontChars) + separator + value.Substring(value.Length - (int)backChars);            
        }
