    var categories4 = from a in art
                      group a by a.Type into g
                      select new
                      {
                          ArtType = g.Key, 
    				      Name = g.Where(a => a.Price == g.Max(b => b.Price))
                                  .Select(a => a.Name).First(),
                          MostExpensive = g.Max(a => a.Price)
                      };
