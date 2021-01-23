    public ActionResult Refresh(string ID)
        {
            DetailsViewModel vm = new DetailsViewModel();  // Model
            vm.productDetails = _product.GetproductDetails(ID); 
            /* "productDetails " is a property in "DetailsViewModel"
            "GetProductDetails" is a method in "Product" class
            "_product" is an interface of "Product" class */
    
            return PartialView("_Details", vm); // Details is a partial view
        }
