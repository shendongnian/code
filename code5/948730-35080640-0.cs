        List<ProductModel> products = GetProducts();
        return View(products);
    }
    
    [HttpPost]
    public AcionResult Products(List<ProductModel> products)
    {
        for each (var prd in products) { if prd.IsChecked }
        ... Do something else
    }
