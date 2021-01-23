    var viewmodel = new AllQuotes();
    viewmodel.Reqs = db.Quotes_Items_Suppliers
            .Include(tbl => tbl.tblItems)
            .Include(tbl => tbl.tblQuotes)
            .Include(tbl => tbl.tblSuppliers)
            .Select(tbl => new Request
            {
                Quote = new Quote { ID = tbl.tblQuotes.ID,
                                    QuoteNo = tbl.tblQuotes.QuoteNo ,
                                    Date = tbl.tblQuotes.RequestDate},
                Supplier = new Supplier { ID = tbl.tblSuppliers.ID,
                                          Name = tbl.tblSuppliers.Supplier,
                                          TelNo = tbl.tblSuppliers.Tel },
                Item = new Item { ID = tbl.tblItems.ID,
                                  Name = tbl.tblItems.Name,
                                  PartNo = tbl.tblItems.PartNo },
                Quantity = tbl.Quantity,
                Price = tbl.Price
            }).ToList();
