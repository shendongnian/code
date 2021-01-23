    public class MyShoppingCartUI()
    {
        private List<IProduct> _productsInCart = new List<IProduct>();
        public void ClickAddProductButton()
        {
            IProduct product = new ProductOne();
            _productsInCart.Add(product);
        }
    }
