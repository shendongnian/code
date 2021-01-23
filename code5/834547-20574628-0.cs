    // one time config
    Mapper.CreateMap<CartEntity, CartViewModel>();
    Mapper.CreateMap<CartItem, CartItemViewModel>();
    Mapper.CreateMap<Item, ItemViewModel>();
    Mapper.CreateMap<Product, ProductViewModel>();
    Mapper.AssertConfigurationIsValid();
    // whenever you map
    CartEntity cart = // whatever
    CartViewModel vm = Mapper.Map<CartViewModel>(cart);
