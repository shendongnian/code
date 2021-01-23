    public static string FixTypo(string needCorrect, int index, string replacement)
    {
        if (needCorrect == null ||
            needCorrect.Length < index || 
            index < 0 || 
            replacement == null) 
        {
            return needCorrect;
        }
        return needCorrect.Substring(0, index) + replacement[0] + 
            needCorrect.Substring(index + 1);
    }
