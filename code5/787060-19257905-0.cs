    Product product;
    try
    {
        product = catalogContext.GetProduct("CatalogName", "ProductId");
    }
    catch (EntityDoesNotExist e)
    {
        product = null;
    }
    
    if (dataGridView1.InvokeRequired)
    {
        // use product here
    }
