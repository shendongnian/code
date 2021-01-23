    var grouped = fd.GroupBy(
                      cl => cl.Itemname,
                      group => new
                          {
                              Itemname = group.Key,
                              TotalAmount = group.Sum(cl => cl.Amount)
                          });
