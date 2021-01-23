    // one time config
    Mapper.CreateMap<Item, ItemViewModel>();
    Mapper.AssertConfigurationIsValid();
    // whenever you map
    Item item = // whatever
    ItemViewModel viewModel = Mapper.Map<ItemViewModel>(item);
    // viewModel.Products is populated from item.GetProducts()
