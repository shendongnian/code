    public class CustomEntityFrubber
    {
        public CustomEntityFrubber(IOrganizationService service, Guid entityIdToFrub)
        {
            this.service = service;
            this.entityId = entityIdToFrub;
        }
        public void FrubTheEntity()
        {
            // Do something with service and entityId.
        }
        private readonly IOrganizationService service;
        private readonly Guid entityId;
    }
---
    // Initialised by the plugin's Execute method.
    public static class GlobalPluginParameters
    {
        public static IOrganizationService Service
        {
            get { return service; }
            set { service = value; }
        }
        public static Guid EntityIdToFrub
        {
            get { return entityId; }
            set { entityId = value; }
        }
        [ThreadStatic]
        private static IOrganizationService service;
        [ThreadStatic]
        private static Guid entityId;
    }
    public class CustomEntityFrubber
    {
        public FrubTheEntity()
        {
            // Do something with the members on GlobalPluginParameters.
        }
    }
