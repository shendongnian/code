    public class ApiHttpControllerSelector : IHttpControllerSelector
    {
        private const string NamespaceKey = "namespace";
        private const string ControllerKey = "controller";
        private readonly HttpConfiguration _configuration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;
        private readonly HashSet<string> _duplicates;
        private static readonly List<Type> _pluginControllers = new List<Type>();
        public ApiHttpControllerSelector(HttpConfiguration config)
        {
            _configuration = config;
            _duplicates = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
            _pluginControllers.AddRange(ApiFramework.PluginHelper.Controllers);
        }
        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);
            var assembliesResolver = _configuration.Services.GetAssembliesResolver();
            var controllersResolver = _configuration.Services.GetHttpControllerTypeResolver();
            var controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver)
                .Concat(_pluginControllers).ToList();               
            foreach (var t in controllerTypes)
            {
                var key = string.Format("{0}.{1}", t.Namespace, t.Name);
                dictionary[key] = new HttpControllerDescriptor(_configuration, t.Name, t);
            }
            return dictionary;
        }
        public System.Web.Http.Controllers.HttpControllerDescriptor SelectController(System.Net.Http.HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));
            }
            string namespaceName = GetRouteVariable<string>(routeData, "namespace");
            if (namespaceName == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));
            }
            string controllerName = GetRouteVariable<string>(routeData, "controller");
            if (controllerName == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));
            }
            // Find a matching controller.
            var baseKey = String.Format(CultureInfo.InvariantCulture, "{0}.{1}Controller", namespaceName, controllerName);
            var key = String.Format("{0}Controller", baseKey);
            HttpControllerDescriptor controllerDescriptor;
            if (_controllers.Value.TryGetValue(key, out controllerDescriptor)) // the default should include the "Controller" at the end of the class name
            {
                return controllerDescriptor;
            }
            else if (_controllers.Value.TryGetValue(baseKey, out controllerDescriptor)) //explicit class name, sans "Controller"
            {
                return controllerDescriptor;
            }
            else if (_duplicates.Contains(key))
            {
                throw new HttpResponseException(
                    request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Multiple controllers were found that match this request."));
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result = null;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }
    }
