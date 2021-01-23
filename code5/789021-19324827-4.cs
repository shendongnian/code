    [TestMethod]
    public void TestMethod2()
    {
        var controller = new CustomerController();
        var result = controller.Create(Customer);
        Assert.AreEqual(1, ((Asd)((ViewResult)result).ViewData.Model).Id);
     }
