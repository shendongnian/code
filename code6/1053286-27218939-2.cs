    public static string FixTypo(string needCorrect, int index, string replacement)
    {
        // Do some argument checks to avoid exceptions
        if (needCorrect == null ||
            needCorrect.Length < index + 1 || 
            index < 0 || 
            replacement == null) 
        {
            // Note, you may want to throw an ArgumentNullException or 
            // ArgumentOutOfRange exception instead...
            return needCorrect;
        }
        return needCorrect.Substring(0, index) + replacement[0] + 
            needCorrect.Substring(index + 1);
    }
