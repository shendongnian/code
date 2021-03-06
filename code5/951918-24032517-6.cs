    public void calistir(int urunid, string GirenIp) 
    {
        using(Models.DermabonEntities db = new Models.DermabonEntities()) 
        {
            // Find the product by primary key
            var product = db.Product.Find(urunid);
            if (product != null) 
            {
                var productName = product.ProductName;
                var productPrice = product.ProductPrice;
                var productId = urunid;
                var productPic = product.ProductPicture;
                var userIp = GirenIp;
                // Get existing basket entry if any based on session/user id and product id
                Basket basket = dn.basket.FirstOrDefault(x=>x.UserId == userIp && x.ProductId == productId);
                if (basket == null) 
                {
                    // basket does not already exist, so add new basket
                    basket = new Basket() 
                    {
                        // You can use property assignment with constructors
                        ProductName = productName,
                        ProductId = productId,
                        ProductPrice = productPrice,
                        ProductPic = productPic,
                        UserId = userIp,
                        ProductQuantity = 1      // Your initial quantity
                    }
                    db.Basket.Add(basket);
                } 
                else 
                {
                    // Existing basket, just increase the quantity
                    basket.ProductQuantity++;
                }
                db.SaveChanges();
            }
        }
    }
