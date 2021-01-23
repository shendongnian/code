    public class TestUnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : IDbContext
    {
        public TContext context { get; set; }
        public TestUnitOfWork(TContext context)
        {
            this.context = context;
        }
    }
    [Test]
    public void GetCorrectUnitOfWork()
    {
        ObjectFactory.Configure(x =>
        {
            x.For(typeof(IUnitOfWork<>)).Use(typeof(TestUnitOfWork<>));
        });
        //ObjectFactory.AssertConfigurationIsValid();
        var securityContextUow = ObjectFactory
            .GetInstance<IUnitOfWork<SecurityContext>>();
        var hrContextUow = ObjectFactory
            .GetInstance<IUnitOfWork<HrContext>>();
        Assert
            .That((securityContextUow as TestUnitOfWork<SecurityContext>).context, 
            Is.InstanceOf<SecurityContext>());
        Assert
            .That((hrContextUow as TestUnitOfWork<HrContext>).context, 
            Is.InstanceOf<HrContext>());
    }
