    public class MyShoppingCartUI()
    {
        private List<IProduct> _productsInCart = new List<IProduct>();
        public void ClickAddProductOneButton()
        {
            IProduct product = new ProductOne();
            _productsInCart.Add(product);
        }
        public void ClickAddProductTwoButton()
        {
            IProduct product = new ProductTwo();
            _productsInCart.Add(product);
        }
    }
