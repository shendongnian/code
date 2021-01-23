    [TestMethod]
    public void ATestMethod()
    {
        using (ShimsContext.Create())
        {
            var myMethodCallTracer = DetectIfMyMethodHasBeenCalled();
            Assert.IsTrue(myMethodCallTracer.WasCalled);
        }
    }
