    var positem = entities.POSEntries.Where( a=> a.Invoice.AccountID == authLogin.userid && a.Invoice.InvoiceStatusID == 1)
                   .GroupBy(x=>x.Item.ItemCode).Select(g=> new {
                                  g.Key,
                                  g.First().Item.Name,
                                  Quantity = g.Count(),
                                  g.First().Item.SellingPrice
                              }).ToList();
