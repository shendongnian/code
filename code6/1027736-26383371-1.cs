    var query = 
        data.GroupBy(d => d.ID)
            .OrderBy(g => g.Key)
            .SelectMany(g => (new[] {new {
                                          g.First().ID, 
                                          g.First().Name, 
                                          g.First().Price}})
                             .Concat(g.Skip(1).Select(i => new {
                                                                ID = (string)null, 
                                                                i.Name, 
                                                                i.Price})));
