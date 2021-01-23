    // find the current tier pricing of the product
    var tierProductPrice = product.ProductPrice.FirstOrDefault(p => p.MinQty >= qtyInCart && p.MaxQty <= qtyInCart);
    
    if (tierProductPrice != null)
    {
     var maxTierQty = tierProductPrice.MaxQty;    
     var tierPrice = tierProductPrice.Price;
     // current price of the Cart
     var cartPrice = tierPrice * qtyInCart;
    
     // find next min price Tier
     var nextTierProductPrice = product.ProductPrice.FirstOrDefault(p => p.MinQty >= maxTierQty && p.MaxQty <= maxTierQty);
    
     if (nextTierProductPrice  != null)
     {
      var itemsToAdd = nextTierProductPrice.MinQty - qtyInCart;
      // calculate new price of the cart
      var newPrice = nextTierProductPrice.MinQty * nextTierProductPrice.Price;
    
      if (newPrice < cartPrice)
      {
       productSaving = new ProductSaving
       {
        QtyToAdd = itemsToAdd,
        Savings = cartPrice - newPrice
       };
      }
     } 
    }
