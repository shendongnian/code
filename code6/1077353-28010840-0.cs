    public static IWindsorContainer GetContainer()
    {
        var container = new WindsorContainer();
        container.Register(Castle.MicroKernel.Registration.Component.For<IInvestigationBox>()
            .ImplementedBy<InvestigationBox>());
        container.Register(Castle.MicroKernel.Registration.Component.For<IInvestigationBoxFactory>()
            .ImplementedBy<IInvestigationBoxFactory>());
        container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
        return container;
    }
