    HashSet<string> propA = new HashSet<string>();
    HashSet<string> propB = new HashSet<string>();
    for (int i = 0; i < list.Count; i++)
    {
        if (!propA.Add(list[i].PropA))
        {
            list[i].PropA = string.Empty;
        }
        if (!propB.Add(list[i].PropB))
        {
            list[i].PropB = string.Empty;
        }
    }
