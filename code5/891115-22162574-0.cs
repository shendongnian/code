    [TestMethod]
    public void TestMethod1()
    {
        using (ShimsContext.Create())
        {
            Something.Fakes.ShimClassA.MethodA = () =>
            {
                Something.Fakes.ShimClassA.MethodA = () =>
                {
                    return "Second";
                };
                return "first";
            };
            var f = Something.ClassA.MethodA();      // first
            var s = Something.ClassA.MethodA();      // second
            var t = Something.ClassA.MethodA();      // second
        }
        var orig = Something.ClassA.MethodA();      // This will use the original implementation of MethodA
    }
