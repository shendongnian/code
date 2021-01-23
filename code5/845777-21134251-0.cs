    [TestMethod]
    public void ContractsMatch()
    {
        var asyncMethodsTransformed = typeof(IAsyncFooService)
            .GetMethods()
            .Select(mi => new 
            { 
                ReturnType = mi.ReturnType,
                Name = mi.Name,
                Parameters = mi.GetParameters()
            });
        var syncMethodsTransformed = typeof(IFooService)
            .GetMethods()
            .Select(mi => new
            {
                ReturnType = WrapInTask(mi.ReturnType),
                Name = Asyncify(mi.Name),
                Parameters = mi.GetParameters()
            });
        Assert.That(asyncMethodsTransformed, Is.EquivalentTo(syncMethodsTransformed));
    }
