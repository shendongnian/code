    [Fact]
    public void Foo()
    {
        Func<IContext, object> inRequestScopeCallback = RetrieveInRequestScopeCallback();
        var kernel = new StandardKernel();
        kernel.Bind<string>().ToSelf().InRequestScope();
        IBinding binding = kernel.GetBindings(typeof(string)).Single();
        binding.ScopeCallback.Should().Be(inRequestScopeCallback);
    }
