    public void AddToCart(int id)
    {
        // Begins new life-cycle of BLFrontend
        var frontend = new BLFrontend();
        // or you can wrap it using statement.
        // using(var frontend = new BLFrontend())
        // {
        //    ... code ...
        // }
        // Retrieve the product from the database.           
        ShoppingCartId = GetCartId();
    
        CartItem cartItem = frontend.getAllCartItems().SingleOrDefault(
             c => c.CartItemId == ShoppingCartId
             && c.ProductId == id);
        if (cartItem == null)
        {
            Product temp = frontend.getAllProducts().SingleOrDefault(
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
    
            frontend.addCartItem(cartItem);//The problem starts from here
        }
        else
        {
            cartItem.Quantity++;
            //update
        }
        // end of life-cycle of the instance.
        frontend.Dispose();
    }
    public class BLFrontEnd : IDispose
    {
        private readonly StoreDBEntities dbContext;
        public BLFrontEnd()
        {
            dbContext = new StoreDBEntities();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
        public IQueryable<Cart> getAllCartItems()
        {
           // your logics...
           return dbContext.Carts.AsQueryable();
        }
        public IQueryable<Product> getAllProducts()
        {
           // your logics...
           return dbContext.Products.AsQueryable();
        }
        public bool addCartItem(CartItem CartItemToAdd)
            {
                try
                {
                    //var context = new StoreDBEntities();
                    dbContext.CartItems.Add(CartItemToAdd);
                    return context.SaveChanges() > 0;
    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
    }
