    public bool TryParseDate(string input, out DateTime result)
    {
        if (MatchPattern1(input, result))
        {
           return true;
        }
        if (MatchPattern2(input, result)) 
        {
           return true;
        }
        ...
        return false;
    }
