            var json1 = "{ \"name\" : \"sai\", \"age\" : 22, \"salary\" : 25000}";
            var json2 = "{ \"name\" : \"sai\", \"age\" : 23, \"Gender\" : \"male\"}";
            var object1 = JObject.Parse(json1);
            var object2 = JObject.Parse(json2);
            foreach (var prop in object2.Properties())
            {
                var targetProperty = object1.Property(prop.Name);
                if (targetProperty == null)
                {
                    object1.Add(prop.Name, prop.Value);
                }
                else
                {
                    targetProperty.Value = prop.Value;
                }
            }
            var result = object1.ToString(Formatting.None);
