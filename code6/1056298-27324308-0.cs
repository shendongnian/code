    public static string RemoveDiacritics(this string s)
    {
        s = s ?? string.Empty;
        if (s.Length > 0)
        {
            char[] chars = new char[s.Length];
            int charIndex = 0;
            s = s.Normalize(NormalizationForm.FormD);
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    chars[charIndex++] = c;
            }
            return new string(chars, 0, charIndex).Normalize(NormalizationForm.FormC);
        }
        return s;
    }
    public static string Slugify(this string s)
    {
        s = s ?? string.Empty;
        //First to lower case
        s = s.ToLowerInvariant().RemoveDiacritics();
        //Replace spaces
        s = Regex.Replace(s, @"\s", "-", RegexOptions.Compiled);
        //Remove invalid chars
        s = Regex.Replace(s, @"[^a-z0-9s\-_]", "", RegexOptions.Compiled);
        //Trim dashes from end
        s = s.Trim('-', '_');
        //Replace double occurences of - or _
        s = Regex.Replace(s, @"([\-_]){2,}", "$1", RegexOptions.Compiled);
        return s;
    }
