    public static class StringExtensions
    {
        public static string[] SplitAndKeep(this string s, string seperator)
        {
        	List<string> result = new List<string>();
            string[] obj = s.Split(new string[] { seperator }, StringSplitOptions.None);
    
            for (int i = 0; i < obj.Length; i++)
            {
                result.Add(obj[i]);
            	if (i < obj.Length - 1) result.Add(separator);
            }
            return result.ToArray();
        }
    }
