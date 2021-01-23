    public string FixTypo(string needCorrect, int index, string replacement)
    {
        return String.Concat(
            needCorrect.Substring(0, index),
            replacement,
            needCorrect.Substring(index + 1));
    }
