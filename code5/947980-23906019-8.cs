    [TestMethod]
    public void ATestMethod()
    {
        //Arrange the test...
        MethodTracer tracer = new methodTracer();
    
        using (ShimsContext.Create())
        {
            ShimMyClass.AllInstances.MyMethod = _ => { tracer.WasCalled = true; };
    
            //Act...
        }
    
        Assert.IsTrue(tracer.WasCalled);
    }
