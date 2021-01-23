        var grouped = fd.GroupBy(
                          cl => cl.Itemname,
                          (key, group) => new CartListing
                          {
                              Itemname = key,
                              Amount = group.Sum(cl => cl.Amount),
                              Price = group.Sum(cl => cl.Price)
                          });
