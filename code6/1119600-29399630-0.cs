    var GroupedTags = Tags.GroupBy(c => c.Tag)
        .Select(g => new 
        { 
            name = g.Key, 
            count = g.Count(), 
            date = g.Max(x => x.CreatedDate)
        })
        .OrderBy(c => c.name);
