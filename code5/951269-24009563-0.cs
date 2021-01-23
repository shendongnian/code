    public async void SearchProducts(string Phrase, int id)
    {
        var Products = new List<Products>();
        try
        {
            Products = await _context.Database.SqlQuery<Products>("EXEC Search_Products @pharse",
                           new SqlParameter("pharse", Phrase)).ToList();,
            var searchedProducts = SearchProducts(Phrase);
            var sellingPrice = GetSellingPrice(Id);
            var discounts = GetDiscounts(Id);
            Products = searchedProducts;
            Products = ProcessForSellingPrice(Products, sellingPrice);
            Products = ProcessForDiscounts(Products, discounts, Id);
            CallWhateverMethodYouWantForProduct(Products);
        }
    }
