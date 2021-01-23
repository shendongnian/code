    [TestMethod]
    public void ParameterTest()
    {
        var controller = new PrintController12();
        PrintRequestData request = new PrintRequestData();
        IOldResponse  var = controller.SPrintRequest1(request);
    }
