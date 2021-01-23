    var itemServiceFactory = new Mock<IItemServiceFactory>();
    var itemService = new Mock<IItemService>();
    itemService.Setup(svc => svc.GetItem()).Returns(chrisItem);
    itemServiceFactory.Setup(factory => factory.Create(false))
        .Returns(itemService.Object);
    var itemManager = new ItemManager(itemServiceFactory.Object);
    var theItem = itemManager.GetAnItem(); // Get NRE on _itemService.GetItem as expected
