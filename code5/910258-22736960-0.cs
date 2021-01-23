    var linkCounts = 
        Links.GroupBy(x => x.Url)
             .Select(g => new Link_Counts
                 {
                     Url = g.Key,
                     Count = g.Count()
                 };
    
