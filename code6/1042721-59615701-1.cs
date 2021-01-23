        public class WcfDataService1 : EntityFrameworkDataService<EntityContainer>
        {
            // This method is called only once to initialize service-wide policies.
            public static void InitializeService(DataServiceConfiguration config)
            {
                // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
                config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            }
        }
    }
