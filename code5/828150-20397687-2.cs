    [Test]
    public void TestCustomerRegistration()
    {
        var customer = ObjectFactory.GetInstance<ICustomer>();
        Assert.IsNotNull(customer, "Cannot get an Customer");
        Assert.IsInstanceOf<SpecificCustomerType>(customer, "Wrong customer type"); 
    }
