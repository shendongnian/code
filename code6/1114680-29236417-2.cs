    public void AddToCart(int id)
    {
        // use StoreDBEntities directly, instead of BLFrontend.
        using(var dbContext = new StoreDBEntities())
        {
            // Retrieve the product from the database.           
            ShoppingCartId = 123; // use magic number for this test.
    
            // and use dbContext directly.
            CartItem cartItem = dbContext.Carts.SingleOrDefault(
                 c => c.CartItemId == ShoppingCartId
                 && c.ProductId == id);
            if (cartItem == null)
            {
                Product temp = dbContext.Products.SingleOrDefault(
                     p => p.ProductId == id);
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    CartItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId_ = ShoppingCartId,
                    Product = temp,
                    Quantity = 1,
                };
    
                dbContext.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
                //update
            }
            dbContext.SaveChanges();
        }
    }
