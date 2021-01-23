    public void AddProduct(IBasket basket)
    {
        SqlHelper.ExecuteNonQuery("Add_Basket", new object[] {
            basket.Type,
            basket.ID,
            basket.PackageID,
            basket.PurchasedUnits
        });
    }
