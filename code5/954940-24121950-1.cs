    public static Int64 Base36Decode(string input)
    {
        var reversed = input.ToLower().Reverse();
    
        long result = 0;
        int pos = 0;
    
        foreach (char c in reversed)
        {
            result += CharList.IndexOf(c) * (long)Math.Pow(36, pos);
            pos++;
        }
    
        return result;
    }
