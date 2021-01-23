    public class ProductFactory()
    {
        public IProduct Create(string productName)
        {
            if (productName == "Product1")
                return new ProductOne();
            else if (productName == "Product2")
                return new ProductTwo();            
        }
    }
    public class MyShoppingCartUI()
    {
        private ProductFactory _factory = new ProductFactory();
        private List<IProduct> _productsInCart = new List<IProduct>();
        public void AddItem(string productName)
        {
            IProduct product = _factory.Create(productName);
            _productsInCart.Add(product);
        }
    }
