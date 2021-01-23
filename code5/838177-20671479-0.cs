    public static string LongestCommonSubstring(List<string> strings)
    {
        var firstString = strings.FirstOrDefault();
    
        var allSubstrings = new List<string>();
        for(int substringLength = firstString.Length -1; substringLength >0; substringLength--)
        {
            for(int offset = 0; (substringLength + offset) < firstString.Length; offset++)
            {
                string currentSubstring = firstString.Substring(offset,substringLength);
                if (!System.String.IsNullOrWhiteSpace(currentSubstring) && !allSubstrings.Contains(currentSubstring))
                {
                    allSubstrings.Add(currentSubstring);
                }
            }
        }
    
        return allSubstrings.OrderBy(subStr => subStr.Length).FirstOrDefault();
    }
