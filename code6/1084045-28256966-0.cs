    List<string> productIds = new List<string>();
    foreach (var product in myProducts) // << Change myProducts and set your collection of products. myProducts contains for example 2000 items.
    {
        productIds.Add(product.ProductId);
    }
    
    var asyncListingInformation = CurrentApp.LoadListingInformationByProductIdsAsync(productIds);
    asyncListingInformation.Completed = (async, status) =>
    {
        try
        {
            var listingInformation = async.GetResults();
            int count = 0; // Compute count of returned products
    
            foreach (var pair in listingInformation.ProductListings)
            {
                string productId = pair.Value.ProductId;
                string price = pair.Value.FormattedPrice;
    
                this.UpdateProductPrice(productId, price);
                count++;
            }
            Debug.WriteLine(count);  // Returns: 2000 :-)
        } 
        catch (Exception e)
        {
        }
    };
