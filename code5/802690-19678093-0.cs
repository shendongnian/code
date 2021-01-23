    public static string testString(string[] input, string startString)
        {
            int max = 0;
            try
            {
                max = input.Where(s => s.StartsWith(startString) && s.Length > startString.Length)
                           .Max(s => int.Parse(s.Replace(startString, string.Empty)));
            }
            catch
            {
                // no worries, this means max was "abc" without a number
            }
            return string.Format("{0}{1}", startString, (max + 1).ToString());
        
        }
