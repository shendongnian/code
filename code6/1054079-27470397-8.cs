    [TestMethod]
    public void Base_controller_must_have_MaxLengthFilter_attribute()
    {
        var att = typeof(BaseController).GetCustomAttribute<MaxLengthAttribute>();
        Assert.IsNotNull(att);
    }
