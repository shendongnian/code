    public static bool IsMatch(string str, string pattern)
    {
    	string regexString = "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
    	Regex regex = new Regex(regexString);
    	return regex.IsMatch(regexString);
    }
