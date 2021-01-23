    [TestMethod()]
    public void GetBillInfoTest()
    {
        BnrHelperMethods target = new BnrHelperMethods();
        dynamic valueItem = new ExpandoObject();
        valueItem.Currency = "USD" ;
        valueItem.BillValue = 100;
            
        var mockItem = new Mock<IConfigurationItem>();
            
        mockItem.Setup(i => i.DynamicValueItem).Returns ((object)valueItem);
        target.GetBillInfo(mockItem.Object);
    }
