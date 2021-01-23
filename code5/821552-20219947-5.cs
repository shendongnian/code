    int val = 0;
    if (a.Company.Name.ToLower.Contains(itemLower))
        val += 5;
    if (a.Title.ToLower.Contains(itemLower))
        val += 3;
    if (a.FullDescription.ToLower().Contains(itemLower))
        val += 2;
    if (val > 0)
    {
        baseResi;t/Add(new SearchResult { ID = a.ID, Value = val });
    }
