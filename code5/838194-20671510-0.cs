    list.Select(item => item.Split('/'))
        .GroupBy(tokens => tokens[0], tokens => tokens[1])
        .Select(g => new TheClass
                         {
                             Category = g.Key,
                             SubCategory = g.ToList()
                         });
