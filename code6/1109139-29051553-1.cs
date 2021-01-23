    public static class StringExtensions
    {
        public static string[] SplitAndKeep(this string s, string[] seperators)
        {
            List<string> result = new List<string>();
            string[] obj = s.Split(seperators, StringSplitOptions.None);
    
            for (int i = 0; i < obj.Length; i++)
            {
                result.Add(obj[i]);
                if (i < obj.Length - 1) result.Add(separator);
            }
            return result.ToArray();
        }
    }
