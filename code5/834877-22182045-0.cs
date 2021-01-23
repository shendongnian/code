    List<Product> result = pr
                         .GroupBy(g => new Tuple<string, decimal>(g.Title, g.Price))
                         .Select(x => new Product()
                                 { 
                                      Title = x.Key.Item1, 
                                      Price = x.Key.Item2,
                                      Color = string.Join(", ", x.Value.Select(y => y.Color) // "Red, Green"
                                 })
                         .ToList();
