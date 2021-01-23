        public int ThaiLength(string text)
        {
            int c = 0;
            int l = text.Length;
            for (int i = 0; i < l; ++i)
            {
                if (char.GetUnicodeCategory(text[i]) != System.Globalization.UnicodeCategory.NonSpacingMark) ++c;
            }
            return c;
        }
