    var result = datatable.AsEnumerable()
                          .GroupBy(r => DateTime.Parse(r["PaymentMonth"].ToString()).Year)
                          .Select(x=> new { Year = x.Key, 
                                            Amount = x.Sum(r=>Int32.Parse(r["Amount"])
                                          }
                         ).OrderBy(x=>x.Year);
