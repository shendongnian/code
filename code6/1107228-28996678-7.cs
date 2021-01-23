            SerializationBinder binder = new MyBinder(); // Your custom binder.
            using (var stream = GetStream(json))
            using (var reader = new StreamReader(stream, Encoding.Unicode))
            {
                var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                var items = from obj in JsonExtensions.WalkObjects(reader)
                          let jType = obj["Type"]
                          let jInstance = obj["Instance"]
                          where jType != null && jType.Type == JTokenType.String
                          where jInstance != null && jInstance.Type == JTokenType.Object
                          let type = binder.BindToType(assemblyName, (string)jType)
                          where type != null
                          select jInstance.ToObject(type); // Deserialize to bound type!
                foreach (var item in items)
                {
                    // Handle each item.
                    Debug.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
