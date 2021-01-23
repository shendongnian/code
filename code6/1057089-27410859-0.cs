    public class EFDS : EntityFrameworkDataService<ModelContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.SetEntitySetAccessRule("Customers", EntitySetRights.All);
        }
    }
