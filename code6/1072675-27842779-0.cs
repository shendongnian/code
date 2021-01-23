    Enumerable.Empty<object>()
        // looks from the naming its a private variable, 
        //so you might want to call it via , GetProperty("subitem", BindingFlags.NonPublic) 
        .OrderBy(x => 
        {
            var subitem = x.GetType().GetProperty("subitem").GetValue(x);
            return subitem.GetType().GetProperty("value").GetValue(x);
        })
        .ToList();
