    private static bool CheckForUniqueChars(string stringToCheck)
    {
        var chars = stringToCheck.ToCharArray();
        for (int i = 0; i < stringToCheck.Length - 1; i++)
        {
            for (int j = i; j < stringToCheck.Length - 1; j++)
            {
                if (Char.ToUpper(chars[i]) == Char.ToUpper(chars[j+1]))
                {
                    return false;
                }
            }
        }
        return true;           
    }
