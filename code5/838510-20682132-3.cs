    var result = dbQuoteItemsSuppliers
                .Include(tbl => tbl.Item)
                .Include(tbl => tbl.Quote)
                .Include(tbl => tbl.Supplier).GroupBy(tbl => new { tbl.Quote, tbl.Supplier, tbl.Item })
                .Select(grouped => new QuoteItemSuppliers
                    {
                        Quote = grouped.Key.Quote,
                        Supplier = grouped.Key.Supplier,
                        Item = grouped.Key.Item,
                        Quantity = grouped.Sum(tbl => tbl.Quantity),
                        Price = grouped.Sum(tbl => tbl.Price)
                    });
