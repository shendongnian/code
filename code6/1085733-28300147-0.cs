    var result = datatable.AsEnumerable()
                          .GroupBy(x=>x["PaymentMonth"])
                          .Select(x=> new { Year = DateTime.Parse(x.Key).Year, 
                                            Amount = x.Sum(r=>Int32.Parse(r["Amount"])
                                          }
                         ).OrderBy(x=>x.Year);
