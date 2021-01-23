    PROJ_ClientAccount Client = db.PROJ_ClientAccount.Where(x => x.Id == 1).FirstOrDefault();
    
    if (Client == null)
    {
    throw new Exception("Error creating new Order Record, Client Account can't be empty");
    }
    
    PROJ__VATRateRecord VatRecord = db.PROJ_VATRateRecord.Where(x => x.Id == 2).FirstOrDefault();
    
    if (VatRecord == null)
    {
    throw new Exception("Error creating new Order Record, VAT can't be empty");
    }
    
    PROJ__ProductRecord ProductRecord = db.PROJ_ProductRecord.Where(x => x.Id == sale.Value.ProductId).FirstOrDefault();
    
    if (ProductRecord == null)
    {
    throw new Exception("Error creating new Order Line Record, ProductRecord can't be empty");
    }
    
    
