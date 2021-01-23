        static void Main(string[] args)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var obj = new {Prop1 = "val1", OtherOptions = new {A = "1", B = "2"}};
            
            IDictionary<string, object> result = new Dictionary<string, object>();
            foreach (var kv in GetProps(obj))
            {
                if (!kv.Key.Equals("OtherOptions"))
                    result.Add(kv);
            }
            foreach (var kv in GetProps(obj.OtherOptions))
            {
                result.Add(kv);
            }
            var serialized = serializer.Serialize(result);
        }
        static IEnumerable<KeyValuePair<string, object>> GetProps(object obj)
        {
            var props = TypeDescriptor.GetProperties(obj);
            return
                props.Cast<PropertyDescriptor>()
                     .Select(prop => new KeyValuePair<string, object>(prop.Name, prop.GetValue(obj)));
        }
