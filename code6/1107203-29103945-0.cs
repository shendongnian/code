    // Added the below line
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)] 
	namespace WorkOrderIntegration
	{
		public class WorkOrderService : DataService<WorkOrderEntities>
		{
			public static void InitializeService(DataServiceConfiguration config)
			{
				config.UseVerboseErrors = true;
				config.SetEntitySetAccessRule("*", EntitySetRights.All);
				config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
			}
		}
	}
