    [TestMethod]
    public void deserializationTest()
    {
        var something = Configuration.DeSerialize<Item>(@"d:\CoffeeShop.Items.config");
        Assert.AreEqual("expected item name", something.Name);
    }
