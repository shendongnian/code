    .Select(p => new
        {
            ID = p.ProductID,
            ProductName = p.Product.Name,
            ProductCode = p.Product.Code,                                        
            StockLevel = p.StockItem.WarehouseLocation.Where(w => w.WarehouseID == p.WarehouseID.Value).Count()
        }).OrderBy(l => l.StockLevel).ToArray();
