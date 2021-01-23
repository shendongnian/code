    public ActionResult AddToCart(int productID)
    {
        var addedProduct = storeDB.Products.Find(productID);
        if (addedProduct == null)
        {
            // take some appropriate action here
            // or possibly throw an exception (can't add a missing product to the cart)
        }
        var cart = ShoppingCart.GetCart(this.HttpContent);
    
        cart.AddToCart(addedProduct);
    
        return RedirectToAction("Index");
    }
