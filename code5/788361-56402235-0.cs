    public ActionResult foo(int? productId = null, int? customerId = null)
    {
        // if ProductId has Value:
        if(productId != null)
        {
            Viewbag.ModelType = "Product";
            //... Logic
            return View((dynamic)(productsList))
        }
    
        // if CustomerId has Value:
        if(CustomerId != null)
        {
            Viewbag.ModelType = "Customer";
            //... Logic
            return View((dynamic)(CustomerList))
        }
    }
