    string[] split = BigString.Split(' ').ToLower();
    var duplicates = new Dictionary<string, int>();
    for (int i = 0;i<split.Length;i++)
    {
        int j=i;
        string s = split[i] + " ";
        while(i+j<split.Length)
        {
            j++;
            s += split[j] + " ";
            if (Regex.Matches(BigString, s).Count ==1) break;
            duplicates[s] = Regex.Matches(BigString, s).Count;
        }
    }
