    public static class StringExtensions
    {
        public static string[] SplitAndKeep(this string s, string[] seperators)
        {
            string[] obj = s.Split(seperators, StringSplitOptions.None);
            List<string> result = new List<string>(obj.Length * 2 - 1);
    
            for (int i = 0; i < obj.Length; i++)
            {
                result.Add(obj[i]);
                if (i < obj.Length - 1) result.Add(separator);
            }
            return result.ToArray();
        }
    }
