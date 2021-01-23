    public class ModelBuilder
        {
            public static IEdmModel GetModal()
            {
               ODataConventionModelBuilder builder= new ODataConventionModelBuilder(); 
               builder.EntitySet<Car>("Car");
               builder.EntitySet<Animal>("Animal");
               return model.GetEdmModel();
            }
        }
