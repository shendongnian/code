    public static string Replace(this string stringToSearch, char charToFind, char charToSubstitute)
    {        
        char[] chars = stringToSearch.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
            if (chars[i] == charToFind) chars[i] = charToSubstitute;
    
        return new string(chars);
    }
