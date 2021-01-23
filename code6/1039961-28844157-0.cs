    namespace MyWebApp
    {
        // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
        // visit http://go.microsoft.com/?LinkId=9394801
        public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
               
               
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                XmlConfigurator.Configure();
                DbHelper.getSessionFactory();
    
                ///// **********
                 JsonValueProviderFactory jsonValueProviderFactory = null;
    
                foreach (var factory in ValueProviderFactories.Factories)
                {
                    if (factory is JsonValueProviderFactory)
                    {
                        jsonValueProviderFactory = factory as JsonValueProviderFactory;
                    }
                }
    
                //remove the default JsonVAlueProviderFactory
                if (jsonValueProviderFactory != null) ValueProviderFactories.Factories.Remove(jsonValueProviderFactory);
    
                //add the custom one
                ValueProviderFactories.Factories.Add(new CustomJsonValueProviderFactory());**
           /////*************
            }
        }
    
    
    
    
         ///********
        public sealed class CustomJsonValueProviderFactory : ValueProviderFactory
        {
    
            private static void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, object value)
            {
                IDictionary<string, object> d = value as IDictionary<string, object>;
                if (d != null)
                {
                    foreach (KeyValuePair<string, object> entry in d)
                    {
                        AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
                    }
                    return;
                }
    
                IList l = value as IList;
                if (l != null)
                {
                    for (int i = 0; i < l.Count; i++)
                    {
                        AddToBackingStore(backingStore, MakeArrayKey(prefix, i), l[i]);
                    }
                    return;
                }
    
                // primitive
                backingStore[prefix] = value;
            }
    
            private static object GetDeserializedObject(ControllerContext controllerContext)
            {
                if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    // not JSON request
                    return null;
                }
    
                StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
                string bodyText = reader.ReadToEnd();
                if (String.IsNullOrEmpty(bodyText))
                {
                    // no JSON data
                    return null;
                }
    
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = int.MaxValue; //increase MaxJsonLength.  This could be read in from the web.config if you prefer
                object jsonData = serializer.DeserializeObject(bodyText);
                return jsonData;
            }
    
            public override IValueProvider GetValueProvider(ControllerContext controllerContext)
            {
                if (controllerContext == null)
                {
                    throw new ArgumentNullException("controllerContext");
                }
    
                object jsonData = GetDeserializedObject(controllerContext);
                if (jsonData == null)
                {
                    return null;
                }
    
                Dictionary<string, object> backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                AddToBackingStore(backingStore, String.Empty, jsonData);
                return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
            }
    
            private static string MakeArrayKey(string prefix, int index)
            {
                return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
            }
    
            private static string MakePropertyKey(string prefix, string propertyName)
            {
                return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
            }
        }
       ///*************
    } 
