    [Test]
    public void PowershellVariableSetTest()
    {
        var runSpace = RunspaceFactory.CreateRunspace();
        runSpace.Open();
    
        runSpace.SessionStateProxy.SetVariable("item", "FooBar");
        var a = runSpace.SessionStateProxy.PSVariable.GetValue("item");
    
        Assert.IsTrue(a.ToString() == "FooBar");
    }
