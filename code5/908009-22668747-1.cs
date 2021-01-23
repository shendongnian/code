    public ActionResult Prices()
    {
        var pricesByShop = new List<PriceByShop>();
        // some code here to add an object to the list for each shop
        // initialize Price with existing price or set to 0...
        return View( pricesByShop );
    }
