    public bool stringOnlyAndLimit(String strToCheck)
    {
     return strToCheck.Length < 31 && strToCheck.All(r => char.IsLetter(r));        
     //return strToCheck.Length < 31 && !strToCheck.Any(r => char.IsDigit(r));
    }
