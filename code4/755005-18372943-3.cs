    var result = 
        (from x in items
         group x by 1 into g
         select new Item {
             Id = 1,
             Date = g.Min(g => g.Date),
             Comment = g.Max(g => g.Comment)
         })
        .First();
