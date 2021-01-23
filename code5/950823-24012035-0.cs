        public class JsonNetValueProviderFactory : ValueProviderFactory
        {
            public override IValueProvider GetValueProvider(ControllerContext controllerContext)
            {
                // first make sure we have a valid context
                if (controllerContext == null)
                    throw new ArgumentNullException("controllerContext");
    
                // now make sure we are dealing with a json request
                if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                    return null;
    
                // get a generic stream reader (get reader for the http stream)
                var streamReader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
                // convert stream reader to a JSON Text Reader
                var JSONReader = new JsonTextReader(streamReader);
                // tell JSON to read
                if (!JSONReader.Read())
                    return null;
    
                // make a new Json serializer
                var JSONSerializer = new JsonSerializer();
                // add the dyamic object converter to our serializer
                JSONSerializer.Converters.Add(new ExpandoObjectConverter());
    
                // use JSON.NET to deserialize object to a dynamic (expando) object
                Object JSONObject;
                // if we start with a "[", treat this as an array
                if (JSONReader.TokenType == JsonToken.StartArray)
                    JSONObject = JSONSerializer.Deserialize<List<ExpandoObject>>(JSONReader);
                else
                    JSONObject = JSONSerializer.Deserialize<ExpandoObject>(JSONReader);
    
                // create a backing store to hold all properties for this deserialization
                var backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                // add all properties to this backing store
                AddToBackingStore(backingStore, String.Empty, JSONObject);
                // return the object in a dictionary value provider so the MVC understands it
                return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
            }
    
            private static void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, object value)
            {
                var d = value as IDictionary<string, object>;
                if (d != null)
                {
                    foreach (var entry in d)
                    {
                        AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
                    }
                    return;
                }
    
                var l = value as IList;
                if (l != null)
                {
                    for (var i = 0; i < l.Count; i++)
                    {
                        AddToBackingStore(backingStore, MakeArrayKey(prefix, i), l[i]);
                    }
                    return;
                }
    
                // primitive
                backingStore[prefix] = value;
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
