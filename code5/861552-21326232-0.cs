    var positem = (from a in entities.POSEntries
        where a.Invoice.AccountID == authLogin.userid && a.Invoice.InvoiceStatusID == 1
                          select new
                          {
                              a.Item.ItemCode,
                              a.Item.Name,
                              Quantity = (from b in entities.POSEntries where b.Invoice.AccountID == authLogin.userid && b.Invoice.InvoiceStatusID == 1 select b).Count(),
                              a.Item.SellingPrice
                          }).Distinct().ToList();
