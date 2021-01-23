    List<ProductGroup> result = pr
                         .GroupBy(g => new Tuple<string, decimal>(g.Title, g.Price))
                         .Select(x => new ProductGroup()
                                 { 
                                      Title = x.Key.Item1, 
                                      Price = x.Key.Item2,
                                      Colors = x.Value.Select(y => y.Color)
                                 })
                         .ToList();
