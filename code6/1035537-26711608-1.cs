    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            …
            IEdmModel model = GetModel();
            config.MapODataServiceRoute("*", "*", model);
        }
    
        private static IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            EntitySetConfiguration<Product> product = builder.EntitySet<Product>("Products");
            product.EntityType.Name = "Product";
            product.EntityType.Namespace = "TestAPI.Models";
            product.EntityType.Property(p => p.Name).Name = "DisplayName";
            product.EntityType.Property(p => p.Level).Name = "DisplayLevel";
            return builder.GetEdmModel();
        }
    }
