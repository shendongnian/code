    string[] split = BigString.Split(' ').ToLower();
    duplicates = new string[];
    foreach(string s in split)
    {
        if (split.Count(i => i==s) >1)
        {
            duplicates.Append(s);
        }
    }
