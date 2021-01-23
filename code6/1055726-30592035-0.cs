    public string ReplaceOnceAtIndex(string text, string search, string replace, int index)
    {
        if (index < 0)
            return text;
        return text.Substring(0, index) + replace + text.Substring(index + search.Length);
    }
    // ... And thenin the caller ...
    var res2 = rx1.Replace(str1, m => 
    ReplaceOnceAtIndex(m.Value, m.Groups["somedigit"].Value, "35", m.Groups["somedigit"].Index));
    // Result: QB35-G2456
