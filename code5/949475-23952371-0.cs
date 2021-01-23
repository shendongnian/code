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
    
        // parse the xml for an object
        private T DeserializeObject<T>(XElement dict) where T:new()
        {
            var obj = new T();
            var objType = typeof (T);
            // iterate over the key elements and match them against
            // the names of the properties of ther class
            foreach (var key in dict.Elements("key"))
            {
                var pi = objType.GetProperty(key.Value);
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
