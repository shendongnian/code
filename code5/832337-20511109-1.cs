    public int SearchText(string fromString,string searchText,bool isCaseSensitive)
    {
            RegexOptions options = isCaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
            return Regex.Matches(Regex.Escape(fromString), searchText, options).Count;
    }
