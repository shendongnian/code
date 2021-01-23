    public class MembershipRegistry : Registry
    {
        public MembershipRegistry()
        {
            var commandMappingsConfigurator = For<ICommandMappingsConfigurator>()
                .Use<MembershipCommandMappingsConfigurator>();
            var queryMappingsConfigurator = For<IQueryMappingsConfigurator>()
                .Use<MembershipQueryMappingsConfigurator>();
            For<IMembershipService>()
                .Use<MembershipService>()
                .Ctor<ICommandMappingsConfigurator>().Is(commandMappingsConfigurator)
                .Ctor<IQueryMappingsConfigurator>().Is(queryMappingsConfigurator);
        }
    }
	
	public class MessagingRegistry : Registry
	{
		public MessagingRegistry()
		{
			var commandMappingsConfigurator = For<ICommandMappingsConfigurator>()
				.Use<MessagingCommandMappingsConfigurator>();
			var queryMappingsConfigurator = For<IQueryMappingsConfigurator>()
				.Use<MessagingQueryMappingsConfigurator>();
			For<IMessagingService>()
				.Use<MessagingService>();
				.Ctor<ICommandMappingsConfigurator>().Is(commandMappingsConfigurator)
                .Ctor<IQueryMappingsConfigurator>().Is(queryMappingsConfigurator);
		}
	}
