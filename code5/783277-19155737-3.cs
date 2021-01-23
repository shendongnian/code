     var query =  = db.Transactions
                  .Where(t => t.SrcObjTyp == "13")
                  .Select(t => t.Recon);
     var scenarioAll = query.ToList();
     var invoicesByReconIdQuery = from r in query
                                  from t in r.Transactions
                                  from i in t.InvoiceDetails
                                  group i by r.Id into g
                                  select new { Id = g.Key, Invoices = g.ToList() };
     
                             
     var invoicesByReconId = invoicesByReconIdQuery.ToDictionary(x => x.Id, x => x.Invoices);
     Parallel.ForEach(scenarioAll.Take(100), r =>
     {
         // ### Exception : {"The underlying provider failed on Open."} here ###
         var invoices = invoicesByReconId[r.Id];
     }
