    var outputData = groupedData.Select(g => new {
                                          OrderId = g.Key,
                                          […]
                                          Products = String.Join(", "), g.Select(x => x.Products),
                                          TotalPrice = g.Select(x => x.TotalPrice).Sum()
                                        });
