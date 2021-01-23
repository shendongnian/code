    public static class NormalizationMapping
    {
        public static Dictionary<string, Regex> EncodingMapping;
        static NormalizationMapping()
        {
            if (EncodingMapping == null)
            {
                EncodingMapping = new Dictionary<string, Regex>();
                string strRegex = @"[iìíịỉî]";
                EncodingMapping.Add("i", new Regex(strRegex, 
                    RegexOptions.Multiline | RegexOptions.IgnoreCase));
                strRegex = @"[aăâ]";
                EncodingMapping.Add("a", new Regex(strRegex, 
                    RegexOptions.Multiline | RegexOptions.IgnoreCase));
                strRegex = @"[eě]";
                EncodingMapping.Add("e", new Regex(strRegex,
                    RegexOptions.Multiline | RegexOptions.IgnoreCase));
                strRegex = @"[uú]";
                EncodingMapping.Add("u", new Regex(strRegex, 
                    RegexOptions.Multiline | RegexOptions.IgnoreCase));
                //TODO: add all your mappings
            }
        }
    }
