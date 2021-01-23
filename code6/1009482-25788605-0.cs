    var productTypeDb = db.Set<ProductType>()
        .Include(pt => pt.AttributeCategories)
        .FirstOrDefault(pt => pt.ProductTypeId == productType.ProductTypeId)
    productTypeDb.AttributeCategories.Clear();
    if (chkAttributeCategory != null)
    {
        foreach (string attributeCategory in chkAttributeCategory)
        {
            productTypeDb.AttributeCategories.Add(db.AttributeCategory
                .Find(int.Parse(attributeCategory)));
        }
    }
    productTypeDb.Name = productType.Name;
    productTypeDb.IsActive = productType.IsActive;
    // other properties
    db.SaveChanges();
