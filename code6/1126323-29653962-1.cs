    public void Install(IWindsorContainer container, IConfigurationStore store)
            {    
                container.Register(
                    Component.For<IInterceptor>()
                        .ImplementedBy<ExceptionHandlingIntercepter>().LifestyleTransient(),
                    Classes
                        .FromAssemblyContaining<EcruiterCommands>()
                        .Where(t => t.Name.EndsWith("CommandHandler"))
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest().Configure(c => c.Interceptors<ExceptionHandlingIntercepter>())
                    );
            }
