    foreach (var a in query)
    {
        foreach (var item in search)
        {
            itemLower = item.ToLower();
            int val = 0;
            if (a.Company.Name.ToLower.Contains(itemLower))
                baseResult.Add(new SearchResult { ID = a.ID, Value = 5});
            if (a.Title.ToLower.Contains(itemLower))
                baseResult.Add(new SearchResult { ID = a.ID, Value = 3});
            if (a.FullDescription.ToLower().Contains(itemLower))
                baseResult.Add(new SearchResult { ID = a.ID, Value = 2});
        }
    }
