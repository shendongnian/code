    public class PListParser
    {
        public T Deserialize<T>(Stream stream) where T : new()
        {
            return Deserialize<T>(XDocument.Load(stream));
        }
    
        public T Deserialize<T>(string xml) where T:new()
        {
            return Deserialize<T>(XDocument.Parse(xml));
        }
    
        private T Deserialize<T>(XDocument doc) where T : new()
        {
            return DeserializeObject<T>(
                doc.Document.
                Element("plist").
                Element("dict"));
        }
    
        // parse th xml for an object
        private T DeserializeObject<T>(XElement dict) where T:new()
        {
            var obj = new T();
            var objType = typeof (T);
    
            // get either propertty names or XmlElement values
            var map = GetMapping(objType);
    
            // iterate over the key elements and match them against
            // the names of the properties of ther class
            foreach (var key in dict.Elements("key"))
            {
                var pi = map[key.Value];
                if (pi != null)
                {
                    // the next node is the value
                    var value = key.NextNode as XElement;
                    if (value != null)
                    {
                        // what is the type of that value
                        switch (value.Name.ToString())
                        {
                            case "array":
                                // assume a generic List for arrays
                                // process subelements
                                object subitems = InvokeDeserializeArray(
                                    pi.PropertyType.GetGenericArguments()[0],
                                    value);
                                pi.SetValue(obj, subitems, null);
                                break;
                            case "string":
                                // simple assignment
                                pi.SetValue(obj, value.Value, null);
                                break;
                            case "integer":
                                int valInt;
                                if (Int32.TryParse(value.Value, out valInt))
                                {
                                    pi.SetValue(obj, valInt, null);
                                }
                                break;
                            default:
                                throw new NotImplementedException(value.Name.ToString());
                                break;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("value null");
                    }
                }
                else
                {
                    Debug.WriteLine(key.Value);
                }
            }
            return obj;
        }
    
        // map a name to a properyinfo
        private static Dictionary<string, PropertyInfo> GetMapping(Type objType)
        {
            // TODO: Cache..
            var map = new Dictionary<string, PropertyInfo>();
            // iterate over all properties to find...
            foreach (var propertyInfo in objType.GetProperties())
            {
                // .. if it has an XmlElementAttribute on it
                var eleAttr = propertyInfo.GetCustomAttributes(
                    typeof (XmlElementAttribute), false);
                string key;
                if (eleAttr.Length == 0)
                {
                    // ... if it doesn't the property name is our key
                    key = propertyInfo.Name;
                }
                else
                {
                    // ... if it does the ElementName given the attribute 
                    // is the key.
                    var attr = (XmlElementAttribute) eleAttr[0];
                    key = attr.ElementName;
                }
                map.Add(key, propertyInfo);
            }
            return map;
        }
    
        //http://stackoverflow.com/a/232621/578411
        private object InvokeDeserializeArray(Type type, XElement value)
        {
            MethodInfo method = typeof(PListParser).GetMethod(
                "DeserializeArray",
                BindingFlags.Instance | 
                BindingFlags.InvokeMethod | 
                BindingFlags.NonPublic);
            MethodInfo generic = method.MakeGenericMethod(type);
            return generic.Invoke(this, new object[] {value});
        }
    
        // array handling, returns a list
        private List<T> DeserializeArray<T>(XElement array) where T:new()
        {
            var items = new List<T>();
            foreach (var dict in array.Elements("dict"))
            {
                items.Add(DeserializeObject<T>(dict));
            }
            return items;
        }
    
    }
