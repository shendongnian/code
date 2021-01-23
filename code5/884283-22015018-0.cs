 [System.Web.Services.WebMethod()]
        public static string DeleteCartItem(string catId)
        {
            Customer thisCustomer = Customer.Current;
            var cart = new ShoppingCart(thisCustomer.SkinID, thisCustomer, CartTypeEnum.ShoppingCart, 0, false);
            cart.RemoveItem(Convert.ToInt32(catId), false);
            var path = System.Web.HttpContext.Current.Server.MapPath("22-02-2014__000865.jpg");  
            File.Delete(path);
            return cart.TotalQuantity().ToString();    
    } </code></pre>
