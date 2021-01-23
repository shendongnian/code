               Places = (from p in e.Places
                          where !p.Excluded
                          select new FruitViewModel()
                          {
                              CodLocation = "",
                              CodPlace = p.CodPlace,
                              Name = p.Name
                          }).Union(
                          from r in e.Locations
                          where !r.Excluido
                          select new FruitViewModel()
                          {
                              CodLocation = r.CodLocation,
                              CodPlace = "",
                              Name = p.Name
                          })
