     var ModelItem = new QuoteViewModel {
          Quote = db.Quotes.Where(q => q.ID == QuoteID).ToList(),
          Suppliers = db.Quotes_Items_Suppliers.Include(t => t.tblSuppliers)
                        .Where(s => s.QuoteID == QuoteID).ToList(),
          Items = db.Quotes_Items_Suppliers.Include(t => t.tblItems)
                    .Where(i => i.QuoteID == QuoteID).ToList()
     };
