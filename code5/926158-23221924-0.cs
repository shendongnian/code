    [TestMethod]
    public void ShouldDeleteCustomerWithIdParam()
    {
        var testID = "A test ID";
        var repo = Mock.Create<ICustomerRepository>();
        var customerService = new CustomerService(repo);
        customerService.Delete(testID);
        Mock.Assert(() => repo.DeleteCustomer(testID), Occurs.AtLeastOnce());
    }
