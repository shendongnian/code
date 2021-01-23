    var result = myList.GroupBy(x => {x.name, x.id1, x.id2})
                       .Select(g => new {
                                             Name = grp.Key.name,
                                             TotalQuantity = grp.Sum(x => x.quantity),
                                             AvgPrice = grp.Average(x => x.price),
                                             TotalValue = grp.Sum(x => x.value),
                                             Id1 = grp.Key.id1,
                                             Id2 = grp.Key.id2     
                                         })
                       .ToList();
