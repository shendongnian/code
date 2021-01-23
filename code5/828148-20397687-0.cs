    [Test]
    public void TestCustomerRegistration()
    {
        var res = ObjectFactory.GetInstance<ICustomer>();
        Assert.IsNotNull(res, "Cannot get an Customer");
        Assert.IsInstanceOf<SpecificCustomerType>(res); 
    }
