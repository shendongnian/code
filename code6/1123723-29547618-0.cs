    private static string FrontBack(string str)
    {
        return (new StringBuilder(str).Remove(str.Length - 1, 1)
            .Remove(0, 1).Insert(0, str[str.Length - 1])
            .Insert(str.Length - 1, str[0])).ToString();
    }
    // 1. Remove last character
    // 2. Remove first character
    // 3. Append last character to beginning
    // 4. Append first character to the end 
