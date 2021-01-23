    public static class Numbers
    {
        public static string ChangeToEnglishNumber(this string text)
        {
            var englishNumbers = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                if(char.IsNumber(text[i])) englishNumbers += char.GetNumericValue(text, i);
                else englishNumbers += text[i];
            }
            return englishNumbers;
        }
    }
