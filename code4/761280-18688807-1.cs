    public static class Helper
        {
            private static readonly PluralizationService _NameService =
                PluralizationService.CreateService(new CultureInfo("en-us"));
            // Provides Plural names [ products for Product ]
            // to determinate the name of the result for example products for Product class
    
            private static ModuleBuilder _ModuleBuilder;
    
            static Helper()
            {
                var asmName = new AssemblyName();
    
                asmName.Name = "MyHelpers";
    
                AssemblyBuilder asmBuilder = Thread.GetDomain().DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
    
                _ModuleBuilder = asmBuilder.DefineDynamicModule("MyHelpers");
    
                // Assembly to put runtime generated classes to that.
            }
    
            private static readonly IDictionary<Type, Type> _HelpersCache = new Dictionary<Type, Type>();
    
            public static List<T> ParseFromJsonResult<T>(String json)
            {
                Type resultType = null;
    
                var entityType = typeof(T);
    
                var pluralName = _NameService.Pluralize(entityType.Name).ToLowerInvariant();
                // products for Product class
    
                if (_HelpersCache.ContainsKey(entityType))
                {
                    // better performance
                    resultType = _HelpersCache[entityType];
                }
                else
                {
                    // need another runtime generated class 
                    // result :
                    /* public class products
                       {
                          public List<Product> products;
                       }
                    */
    
                    TypeBuilder resultTypeBuilder = _ModuleBuilder.DefineType(pluralName, TypeAttributes.Public);
    
                    FieldBuilder field = resultTypeBuilder.DefineField(pluralName, typeof(List<T>), FieldAttributes.Public);
    
                    resultType = resultTypeBuilder.CreateType();
    
                    _HelpersCache.Add(entityType, resultType);
                }
    
                Object result = JsonConvert.DeserializeObject(json, resultType);
    
                return (List<T>)resultType.GetField(pluralName).GetValue(result); // get products field value
            }
        }
