    [TestMethod]
    public void TestMethod1()
    {
        var fake = A.Fake<IDatabase>();
        fake.AnyCall().DoesNothing();
    
        var result = fake.Table1;
    
        Assert.IsNull(result);
    }
