    var currentAndHistoricalOnly = ViewCustomerGLAndPurchaseRecord
                                     .Where(g=>g.CashierDate > new DateTime(2012,10,01) && g.CashierDate < new DateTime(2012,12,01)) 
                                     .GroupBy(x => x.TransactionId)
                                     .Select(g=> new {
                                         Last = g.OrderByDescending(c=>c.CashierDate).FirstOrDefault(),
                                         First = g.OrderBy(c=>c.CashierDate).FirstOrDefault(),
                                     })
                                     .ToList();
