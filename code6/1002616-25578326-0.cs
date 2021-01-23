    public class CustomControllerFactory : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var schemaKey = request.Headers.Where(k => k.Key == "schema").FirstOrDefault().Value.FirstOrDefault();
            return (IHttpController)Activator.CreateInstance(controllerType, new string[] { schemaKey });
        }
    }
