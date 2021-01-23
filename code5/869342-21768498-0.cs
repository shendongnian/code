    [Fact()]
    public async void GetCustomer()
    {
        var id = 2;
        _customerMock.Setup(x => x.FindCustomerAsync(id))
            .Returns(Task.FromResult(new Customer()
                     {
                      customerID = 2,
                      firstName = "Tom",
                     }));
        var controller = new CustomersController(_customerMock.Object).GetCustomer(id);
        var result = await controller as Customer;
        Assert.NotNull(result);
    }
