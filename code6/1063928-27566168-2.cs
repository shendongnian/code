    public void Operation(List<string> list)
    {
        if (list == null || list.Count == 0) return;
        int count = list.Count;
        for (int i = 0; i <= count; i++)
            if (i % 2 == 0)
                list.Insert(i + 1, list[i]);
    } 
 
