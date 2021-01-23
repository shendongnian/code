    public class Plugin1Bootstrapper : IPackage
    {
        public void RegisterServices(Container container) {
            container.Register<GenericDAO>(() => new GenericDAO(
                isInUserContext: true, 
                connectionString: "con str", 
                providerName: "System.Sql.Client",
                universalDataAccess: container.GetInstance<UniversalDataAccess>()));
            // other registrations here.
        }
    }
