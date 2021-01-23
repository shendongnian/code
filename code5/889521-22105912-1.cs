    [TestMethod]
    public MyClass_GetWMIProperty_GivenGoodInput_ReturnsString()
    {
        var myClass = new MyClass();
        var result = myClass.GetWMIProperty("goodinput");
        Assert.IsNotNull(result);
    }
    [TestMethod]
    public MyClass_GetWMIProperty_GivenNullInput_ThrowsArgumentNullException()
    {
        var myClass = new MyClass();
        try
        {
            var result = myClass.GetWMIProperty(null);
        }
        catch (ArgumentNullException)
        {
            // Good
            return;
        }
     
        // Exception not thrown
        Assert.Fail();
    }
    [TestMethod]
    public MyClass_GetWMIProperty_GivenBadInput_ReturnsNull()
    {
        var myClass = new MyClass();
        var result = myClass.GetWMIProperty("badinput");
        Assert.IsNull(result);
    }
