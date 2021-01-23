    List<SearchResult> baseResult = new List<SearchResult>();
    foreach (var c in candidates)
    {
        int val = 0;
        if (c.Name.Contains(c.Search))
            val = 5;
        else if (c.Title.Contains(c.Search))
            val = 3;
        else if (c.FullDescription.Contains(c.Search))
            val = 2;
        else
            throw new ApplicationException("this can't happen.");
        baseResult.Add(new SearchResult(ID = c.ID, Value = val));
    }
