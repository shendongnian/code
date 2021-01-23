     var query = from ord in orders
                            group ord by new { ord.Country, ord.PostCode } into g
                            select new
                                {
                                    Country = g.Key.Country,
                                    PostCode = g.Key.PostCode,
                                    Orders = g.GroupBy(x => x.OrderId)
                                              .GroupBy(i => i.Count() > 1 ?
                                                  new { OrderID = i.Key, Email = default(string) }
                                                  : new { OrderID = default(int), i.First().Email })
                                              .Select(o => o.Count() == 1 ?
                                                   new { o.Key, Orders = o.First().ToList() }
                                                   : new { o.Key, Orders = o.Select(z => z.First()).ToList() })
                                };
