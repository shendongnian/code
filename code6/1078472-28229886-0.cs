    public class ModelBuilder
    {
        public static IEdmModel GetModal()
        {
           ODataConventionModelBuildermodel = new ODataConventionModelBuilder(); 
           builder.EntitySet<Car>("Car");
           builder.EntitySet<Animal>("Animal");
           return model.GetEdmModel();
        }
    }
2. Add two end points for different edm models.
    public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataRoute(
            routeName: "OData1",
            routePrefix: "odata1",
            model: ModelBuilder.GetModal1());
    
            config.Routes.MapODataRoute(
            routeName: "OData2",
            routePrefix: "odata2",
            model: ModelBuilder.GetModal2());
        }
Thanks.
