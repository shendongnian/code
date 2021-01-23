    public void AddProduct(IBasket basket)
    {
        var type = (basket is UserBasket) 
                   ? Enumerations.BasketType.User 
                   : Enumerations.BasketType.Anonymous;
        SqlHelper.ExecuteNonQuery("Basket_Add", new object[] { 
                                                                type, 
                                                                basket.ID, 
                                                                basket.PackageID,
                                                                basket.PurchasedUnits 
                                                              });
        // Yes, I do funky things with whitespace to avoid scrollbars on SO...
    }
