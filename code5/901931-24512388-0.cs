    [TestMethod]
    public void TestGetOrderInfo()
    {
        var controller = new OrderController(_repo);
        dynamic results = controller.GetOrderInfo(46);
        dynamic content = results.Content;
        ...
    }
