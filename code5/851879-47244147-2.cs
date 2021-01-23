        public static ISO_639_3 GetISO_639_3(string language)
        {
            // Create list if it does not exist
            if (Program.Default.ISO6393List == null)
            {
                Program.Default.ISO6393List = ISO_639_3.Create();
            }
            // Match the input string type
            ISO_639_3 lang = null;
            if (language.Length > 3 && language.ElementAt(2) == '-')
            {
                // Treat the language as a culture form, e.g. en-us
                CultureInfo cix = new CultureInfo(language);
                // Recursively call using the ISO 639-2 code
                return GetISO_639_3(cix.ThreeLetterISOLanguageName);
            }
            else if (language.Length > 3)
            {
                // Try long form
                lang = Program.Default.ISO6393List.Where(item => item.Ref_Name.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (lang != null)
                    return lang;
            }
            else if (language.Length == 3)
            {
                // Try 639-3
                lang = Program.Default.ISO6393List.Where(item => item.Id.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (lang != null)
                    return lang;
                // Try the 639-2/B
                lang = Program.Default.ISO6393List.Where(item => item.Part2B.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (lang != null)
                    return lang;
                // Try the 639-2/T
                lang = Program.Default.ISO6393List.Where(item => item.Part2T.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (lang != null)
                    return lang;
            }
            else if (language.Length == 2)
            {
                // Try 639-1
                lang = Program.Default.ISO6393List.Where(item => item.Part1.Equals(language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (lang != null)
                    return lang;
            }
            // Not found
            return lang;
        }
