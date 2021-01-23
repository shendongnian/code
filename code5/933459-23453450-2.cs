    Dictionary<string, int> counts = new Dictionary<string, int>();
    for (int i = 0; i < str.Length - 1; i++)
    {
        if (str[i+1] == (char)(str[i]+1))
        {
            string index = "" + str[i] + str[i+1];
            if (!counts.ContainsKey(index))
                counts.Add(index, 0);
            counts[index]++;
        }
    }
