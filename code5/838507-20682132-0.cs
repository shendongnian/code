    var result = dbQuoteItemsSuppliers
                .Include(tbl => tbl.Item)
                .Include(tbl => tbl.Quote)
                .Include(tbl => tbl.Supplier).GroupBy(tbl => new { tbl.Quote, tbl.Supplier, tbl.Item })
                .Select(grouped => new 
                    {
                        grouped.Key.Quote,
                        grouped.Key.Supplier,
                        grouped.Key.Item,
                        Quantity = grouped.Sum(tbl => tbl.Quantity)
                    });    
