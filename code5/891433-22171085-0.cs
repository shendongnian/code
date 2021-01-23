    string Merge(char sep1, char sep2, params string[] items)
    {
        string result = "";
    
        for(int i = 0; i < items.Length; i++)
        {
            result += items[i] + (i % 2 == 0 ? sep1 : sep2);
        }
    
        return result.TrimEnd(sep1, sep2);
    }
