    string searchQuery = collection["query"];    
    var srmas = (
        from SRMAs in db.SRMAs
        join SRMAStatus in db.SRMAStatus on SRMAs.Id equals SRMAStatus.Id
        join PurchaseOrders in db.PurchaseOrders on SRMAs.PONumber equals PurchaseOrders.PONumber
        join Suppliers in db.Suppliers on PurchaseOrders.SupplierID equals Suppliers.SupplierID
        join SRMADetails in db.SRMADetails on SRMAs.Id equals SRMADetails.SRMAId
        where ids.Contains(SRMAs.Status) 
        && 
        (
            searchQuery.Contains(PurchaseOrders.suppliersOrderNumber)
            ||
            searchQuery.Contains(SqlFunctions.StringConvert((double)SRMAs.PONumber))
        )
        select new
        {
            SRMAs.Id,
            SRMAs.PONumber,
            SRMAs.CreatedOn,
            Suppliers.SupplierName,
            SRMAStatus.StatusName,
            PurchaseOrders.PODate, PurchaseOrders.suppliersOrderNumber
        }
    ).ToList();
