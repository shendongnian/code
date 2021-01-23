	public class MyRegistry : Registry
	{
		public MyRegistry()
		{
			For(typeof(ICommandMappingsConfigurator<>))
				.Use(typeof(CommandMappingsConfigurator<>));
			For(typeof(IQueryMappingsConfigurator<>)
				.Use(typeof(QueryMappingsConfigurator<>));
			For<IMessagingService>()
				.Use<MessagingService>();
			For<IMembershipService>()
                .Use<MembershipService>();
		}
	}
	
	public class CommandMappingsConfigurator<MessagingService> : ICommandMappingsConfigurator<MessagingService>
	{
		// ...
	}
	
	public class QueryMappingsConfigurator<MessagingService> : IQueryMappingsConfigurator<MessagingService>
	{
		// ...
	}
	
	public class MessagingService
	{
		public MessagingService(
			ICommandMappingsConfigurator<MessagingService> commandMappingsConfigurator,
			IQueryMappingsConfigurator<MessagingService> queryMappingsConfigurator)
		{
			// ...
		}
	}
	
	public class CommandMappingsConfigurator<MembershipService> : ICommandMappingsConfigurator<MembershipService>
	{
		// ...
	}
	
	public class QueryMappingsConfigurator<MembershipService> : IQueryMappingsConfigurator<MembershipService>
	{
		// ...
	}
	
	public class MembershipService
	{
		public MembershipService(
			ICommandMappingsConfigurator<MembershipService> commandMappingsConfigurator,
			IQueryMappingsConfigurator<MembershipService> queryMappingsConfigurator)
		{
			// ...
		}
	}
