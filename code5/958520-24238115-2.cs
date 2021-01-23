    var stockInfo = from sl in stockLocations
                    group sl by sl.Item into g
                    select new {
                        Total = g.Sum(x => x.Stock),
                        Item = g.Key
                    };
    var sorted = stockInfo.OrderBy(x => x.Item.Name);
    var firstItem = sorted.First();
    Console.WriteLine(firstItem.Item.Name);
    Console.WriteLine(firstItem.Item.Code);
    //etc
