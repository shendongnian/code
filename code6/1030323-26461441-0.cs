    string s1 = "move";
    string s2 = "remove";
    HashSet<char> excludeCharacters = new HashSet(s1);
    StringBuilder sb = new StringBuilder();
    // Copy every character from the original string, except those to be excluded
    foreach (char ch in s2)
    {
        if (!excludeCharacters.Contains(ch))
        {
            sb.Append(ch);
        }
    }
    return sb.ToString();
