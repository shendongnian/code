    [Test]
    public void TestMethod()
    {
        var controllerContext = new HttpControllerContext();
        var request = new HttpRequestMessage();
        request.Headers.Add("TestHeader", "TestHeader");
        controllerContext.Request = request;
        _controller.ControllerContext = controllerContext;
    
        var result = _controller.YourAPIMethod();
        //Your assertion
    }
