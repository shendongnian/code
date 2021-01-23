    var handler = new TestCommandHandler();
    Mock<ICommandHandlerFactory> handlerFactory = new Mock<ICommandHandlerFactory>();
    handlerFactory.Setup(x => x.GetHandler<TestCommand>()).Returns(handler);
    Mock<CommandBus> commandBus = new Mock<CommandBus>();
    commandBus.Setup(x => x.GetHandler<TestCommand>(It.IsAny<TestCommand>())).Returns(handler);
