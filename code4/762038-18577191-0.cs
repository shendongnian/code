        public static string RemoveDiacritics(this string s)
        {
            if (s == null) throw new ArgumentNullException("s");
            string formD = s.Normalize(NormalizationForm.FormD);
            char[] chars = new char[formD.Length];
            int count = 0;
            foreach (char c in formD)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    chars[count++] = c;
                }
            }
            string noDiacriticsFormD = new string(chars, 0, count);
            return noDiacriticsFormD.Normalize(NormalizationForm.FormC);
        }
