    public IEnumerable<PurchaseOrder> Find(Filter filter)
            {
                string query = "SELECT PurchaseDate, InvoiceNo, Supplier, Total FROM PurchaseOrder WHERE 1 = 1";
    
                if (!string.IsNullOrEmpty(purchaseOrder.InvoiceNo))
                {
                    query += " AND InvoiceNo = @InvoiceNo";
                }
                if (purchaseOrder.PurchaseDate != DateTime.MinValue)
                {
                    query += " AND PurchaseDate = @PurchaseDate";
                }
    
                return this._db.Query<PurchaseOrder>(sql, filter);
            }
