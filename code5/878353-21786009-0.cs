    @{
        var categories = new List<int>() { 6, 7 };
    
        var parameters = new RouteValueDictionary();
    
        for (int i = 0; i < categories.Count; ++i)
        {
            parameters.Add("category[" + i + "]", categories[i]);
        }
    }
