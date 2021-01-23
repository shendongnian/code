    string prev = list.First().PropA;
    foreach (var item in list.Skip(1))
    {
        if (item.PropA == prev)
        {
            item.PropA = string.Empty;
            item.PropB = string.Empty;
        }
        else
        {
            prev = item.PropA;
        }
    }
