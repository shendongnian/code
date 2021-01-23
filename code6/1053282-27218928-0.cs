    public string FixTypo(string needCorrect, int index, string replacement)
    {
        needCorrect = needCorrect.Substring(index, 1);
        return needCorrect;
    }
