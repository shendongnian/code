    public static bool IsAllCharLowerCase(string ext)
    {
        foreach(char c in ext)
        {
             if (char.IsUpper(c))
             {
                 return false;
             }
        }
        return true;
    }
