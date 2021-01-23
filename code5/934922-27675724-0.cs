    public static class ODataConfig
        {
            public static void Register(HttpConfiguration config)
            {
                ODataModelBuilder builder = new ODataConventionModelBuilder();
                builder.EntitySet<EntityName>(typeof(EntityName).Name);
                var model = builder.GetEdmModel();
                config.Routes.MapODataRoute("odata", "odata", model);
    
                config.EnableQuerySupport();
            }
        }
