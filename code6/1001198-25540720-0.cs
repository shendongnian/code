    public T FindMatch(string pattern, GetKeyDelegate getKey)
    {
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
    
        foreach (T item in this.Items)
        {
            string key = getKey(item);
            Match match = rgx.Match(key);
            if (match.Success)
                return item;
        }
    
        return default(T);
    }
