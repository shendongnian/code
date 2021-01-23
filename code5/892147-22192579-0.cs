    public void TestSwitch()
    {
        foreach (var variable in (SomeEnum[])Enum.GetValues(typeof(SomeEnum)))
            Assert.DoesNotThrow(() => YourMethod(variable), "Value {0} not supported", variable);
    }
