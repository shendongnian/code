        static void Main(string[] args)
        {
            String str = "{dog} and the {cat}";
            String[] ret = ExtractTagValue(str);
        }
        public static String[] ExtractTagValue(String input)
        {
            List<String> retLst = new List<string>();
            
            String pattern = "(\\{.*?\\})";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            System.Text.RegularExpressions.MatchCollection matches = regex.Matches(input);
            if (matches.Count > 0)
            {
                
                foreach (Match match in matches)
                {
                    retLst.Add(match.Value);
                }
            }
            return retLst.ToArray();
        }
