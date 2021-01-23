    public static void IsAllCharLowerCase(string ext)
    {
        foreach(char c in ext)
        {
             if (char.IsUpper(c))
             {
                 return true;
             }
        }
        return false;
    }
