    public class WindsorInfrastructureInstaller : IWindsorInstaller
    {
    	public void Install(IWindsorContainer container, IConfigurationStore store)
    	{
    		// Resolvers
    		//container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
    
    		// TypedFactoryFacility
    		container.AddFacility<TypedFactoryFacility>();
    	}
    }
