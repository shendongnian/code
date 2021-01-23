    public class PoorMansCompositionRoot : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            if (controllerType == typeof(ImportJsonController))
                return new ImportJsonController(new MyFilter());
     
            return null;
        }
    }
