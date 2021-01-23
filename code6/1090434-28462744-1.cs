    public DAL.IDAL db { private get; set; }
    
    [TestInitialize]
    public void InitializeTests()
    {
        var kernel = new Ninject.StandardKernel();
        db = kernel.Get<DAL.MyDAL>(new PropertyValue("user", new Test.User());
    }
