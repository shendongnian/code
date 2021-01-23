    public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(
                    Component.For<IUnitOfWork>().ImplementedBy(typeof (UnitOfWork)).LifestylePerWebRequest());
    
                container.Register(
                    Classes
                        .FromAssemblyContaining<EcruiterCommands>()
                        .Where(t => t.Name.EndsWith("Commands"))
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest());
    
                container.Register(
                    Component.For<IInterceptor>()
                        .ImplementedBy<TransactionHandlingInterceptor>().LifestyleTransient(),
                    Classes
                        .FromAssemblyContaining<EcruiterCommands>()
                        .Where(t => t.Name.EndsWith("CommandHandler"))
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest().Configure(c => c.Interceptors<TransactionHandlingInterceptor>())
                    );
            }
