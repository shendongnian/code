    public void If_Cart_Already_Exists_Then_AddToBasket_Should_Use_It_ByCallingIShoppingCartGetCart() 
    {
        ShoppingCart cart = new ShoppingCart();  //without UserName as ctor parameter
        IShoppingCartRepository shoppingCartRepository = MockRepository.GenerateMock<IShoppingCartRepository>();
        shoppingCartRepository.Stub(r => r.GetCart()).Return(cart);
        ShoppingCartController c = new ShoppingCartController(shoppingCartRepository); //DI
        c.AddToCart(PRODUCT_ID);//interAct
        shoppingCartRepository.AssertWasCalled(r => r.GetCart());
    }
