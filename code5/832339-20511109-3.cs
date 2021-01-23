    public int SearchText(string fromString, string searchText, bool isCaseSensitive)
    {
            RegexOptions options = isCaseSensitive ? 
                RegexOptions.None : RegexOptions.IgnoreCase;
            return Regex.Matches(fromString, Regex.Escape(searchText), options).Count;
    }
