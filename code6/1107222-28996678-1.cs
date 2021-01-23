            SerializationBinder binder = new MyBinder(); // Your custom binder.
            IEnumerable<object> items;
            using (var stream = GetStream(json))
            using (var reader = new StreamReader(stream, Encoding.Unicode))
            {
                items = JsonExtensions.WalkObjects(reader)
                    .Where(obj => obj["Instance"] != null && obj["Instance"].Type == JTokenType.Object) // Has an "Instance" sub-object property
                    .Where(obj => obj["Type"] != null && obj["Type"].Type == JTokenType.String)         // Has a "Type" string property.
                    .Where(obj => binder.BindToType(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, (string)obj["Type"]) != null)  // Type name maps to a bindable type.
                    .Select(obj => obj["Instance"].ToObject(binder.BindToType(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, (string)obj["Type"])));
                foreach (var item in items)
                {
                    // Handle each item.
                    Debug.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
