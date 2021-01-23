            var itemServiceFactoryBroken = new Mock<IItemServiceFactory>(MockBehavior.Strict); //Strict behavior is important!!
            itemServiceFactoryBroken.Setup(factory => factory.Create(false).GetItem()).Returns(chrisItem); //expecting this to fail, because IItemServiceFactory.Create(true) is configured
            itemManager = new ItemManager(itemServiceFactoryBroken.Object);
            theItem = itemManager.GetAnItem();
            Console.WriteLine("The item is {0} and costs {1}", theItem.Name, theItem.Price);
