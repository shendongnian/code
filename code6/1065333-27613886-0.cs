     string query = "SELECT PurchaseDate, InvoiceNo, Supplier, Total FROM PurchaseOrder     WHERE 1 = 1";
     if (!string.IsNullOrEmpty(purchaseOrder.InvoiceNo))
     {
         sql += " AND InvoiceNo = @InvoiceNo";
     }
     if (purchaseOrder.PurchaseDate != DateTime.MinValue)
     {
        sql += " AND PurchaseDate = @PurchaseDate";
     }
      return this._db.Query<PurchaseOrder>(sql, new {InvoiceNo = new DbString { Value =     YourInvoiceNoVariable, IsFixedLength = true, Length = 10, IsAnsi = true });
