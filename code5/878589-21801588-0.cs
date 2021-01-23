    HashSet<string> set = new HashSet<string>();
    for (int i = 0; i < str.Length; i++)
    {
        string s;
        if (char.IsHighSurrogate(str[i]))
        {
            s = str.Substring(i, 2);
            i++;
        }
        else
        {
            s = str.Substring(i, 1);
        }
        if (!set.Add(s))
        {
            return false;
        }
    }
    return true;
