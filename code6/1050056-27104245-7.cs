    var factory = new Mock<IViewModelFactory>();
    var repository = new Mock<INewsRepository>();
    var delegateHelper = new Mock<IDelegateHelper >();
    var customerContext = new Mock<ICustomerContextWrapper >();
    
    var orderController = new OrderController(factory.Object, repository.Object, delegateHelper.Object, customerContext.Object);
