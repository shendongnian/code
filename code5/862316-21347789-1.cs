    // input generation
    var input = Enumerable.Range(1, 22)
                          .Select(x => new { ID = x, Item = "ITEM01", Quantity = 10 })
                          .Concat(Enumerable.Range(23, 2)
                                            .Select(x => new { ID = x, Item = "ITEM02", Quantity = 50 }));
    // query you're asking for
    var output =
        input.GroupBy(x => x.Item) // group by Item first
             .Select(g => g.Select((v, i) => new { v, i }) // select indexes within group
                           .GroupBy(x => x.i / 10)  // group items from group by index / 10
                           .Select(g2 => g2.Select(x => x.v))  // skip the indexes as we don't need them anymore
                           .SelectMany(g2 =>  // flatten second grouping results and apply Sum logic
                               g2.Count() == 10  
                                   // if there are 10 items in group return only one item with Quantity sum
                               ? new[] { new { Item = g.Key, Quantity = g2.Sum(x => x.Quantity) } }
                                   // if less than 10 items in group return the items as they are
                               : g2.Select(x => new { Item = g.Key, Quantity = x.Quantity })))
              .SelectMany(g => g);  // flatten all results
