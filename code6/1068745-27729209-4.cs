    var itemServiceFactory = Mock.Of<IItemServiceFactory>(
        fac => fac.Create(false) == Mock.Of<IItemService>(
            svc => svc.GetItem() == chrisItem));
    var itemManager = new ItemManager(itemServiceFactory);
    var theItem = itemManager.GetAnItem();
