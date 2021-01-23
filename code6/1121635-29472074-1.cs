    [Test]
    public void EditCustomerShouldReturnExceptionWhenCustomerIsNotCreated()
    {
        var c = new CustomerViewModel();
        var customerRepositoryMock = Substitute.For<ICustomerRepository>();
        var customerService = new CustomerService(customerRepositoryMock);
        customerRepositoryMock.Update(Arg.Any<Customer>()).Returns(x => { throw new Exception(); });
        Assert.Throws<Exception>(() => customerService.EditCustomer(c));
    }
    [Test]
    public void EditCustomerShouldReturnTrueWhenCustomerIsCreated()
    {
        var c = new CustomerViewModel();
        var customerRepositoryMock = Substitute.For<ICustomerRepository>();
        var customerService = new CustomerService(customerRepositoryMock);
        customerRepositoryMock.Update(Arg.Any<Customer>()).Returns(true);
         Assert.IsTrue(customerService.EditCustomer(c));
    }
