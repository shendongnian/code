    [TestMethod]
    public void TestMethod2()
    {
        var kernel = new StandardKernel();
        kernel.Bind(c => c.FromThisAssembly()
                            .IncludingNonePublicTypes()
                            .SelectAllClasses()
                            .InheritedFrom(typeof(IQueryHandler<,>))
                            .BindSingleInterface());
        kernel.TryGet<IQueryHandler<GetPagedPostsQuery,PagedResult<Post>>>()
            .Should()
            .NotBeNull();
    }
