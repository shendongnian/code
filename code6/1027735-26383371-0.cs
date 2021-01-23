    var query = 
        data.GroupBy(d => d.ID)
            .OrderBy(g => g.Key)
            .SelectMany(g => (new[] {new {
                                          ID = new int?(g.First().ID), 
                                          g.First().Name, 
                                          g.First().Price}})
                             .Concat(g.Skip(1).Select(i => new {
                                                                ID = new int?(), 
                                                                i.Name, 
                                                                i.Price})));
