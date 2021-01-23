    [Test]
    public void RewriteBindingConditionTest()
    {
        _kernel = new StandardKernel(new MyModule());
        var instance = _kernel.Get<MyClass>();
        Assert.IsInstanceOf<MyFirstType>(instance.Type1);
        Assert.IsInstanceOf<MySecondType>(instance.Type2);
        Assert.IsInstanceOf<MyThirdType>(instance.Type3);
        try
        {
            _kernel.Get<MyOtherClass>();
        }
        catch (ActivationException)
        {
            Assert.Pass();
        }
        Assert.Fail("Bindings were injected into MyOtherClass while there was no configured binding for them.");
    }
