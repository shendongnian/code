    public string Formatter(string MainText, char CharToRemove)
    {
        string result = MainText;
        foreach (char c in result)
        {
            if(c == CharToRemove)
            result = result.Remove(result.IndexOf(c), 1);
        }
        return result;
    }
