    var result = db.Quotes_Items_Suppliers
                .Include(tbl => tbl.tblItems)
                .Include(tbl => tbl.tblQuotes)
                .Include(tbl => tbl.tblSuppliers)
                .GroupBy(tbl => new { tbl.tblQuotes,tbl.tblSuppliers, tbl.tblItems })
                .Select(grouped => new QuoteViewModel
                {
                    Quote = new Quote{ID=grouped.Key.tblQuotes.ID,
                                      QuoteNo =grouped.Key.tblQuotes.QuoteNo ,
                                      Date= grouped.Key.tblQuotes.Date},
                    Supplier = grouped.Key.tblSuppliers,
                    Item = grouped.Key.tblItems,
                    Quantity = grouped.Sum(tbl => tbl.Quantity),
                    Price = grouped.Sum(tbl => tbl.Price)
                }); 
