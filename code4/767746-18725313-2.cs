    public static bool stringOnlyAndLimit(String strToCheck)
    {
        Regex stringonly = new Regex("^[a-zA-Z ]{1,30}$");
        return stringonly.IsMatch(strToCheck);
    }
