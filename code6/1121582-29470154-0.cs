    var viewModel = new CustomerViewModel();
    var customerRepositoryMock = new Mock<ICustomerRepository>();
    // If you just want to test out the behavior of an exception being thrown,
    // regardless of what is passed in
    customerRepositoryMock
        .Setup(r => r.Update(It.IsAny<CustomerViewModel>()))
        .Throws<Exception>();
    // If you need to throw an exception when the viewmodel contains certain properties
    customerRepositoryMock
        .Setup(r => r.Update(It.Is<CustomerViewModel>(c => c.Id == viewModel.Id)))
        .Throws<Exception>();
    // If you need to throw an exception with specific properties, and verify those
    customerRepositoryMock
        .Setup(r => r.Update(It.Is<CustomerViewModel>(c => c.Id == viewModel.Id)))
        .Throws(new Exception("some message"));
