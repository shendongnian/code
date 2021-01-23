            var obj = JObject.Load(reader);
            foreach (var property in obj.Properties())
            {
                switch (property.Name)
                {
                    case "Data2":
                        {
                            // For example
                            myClass.Data2 = obj.ToObject<List<double>>(serializer);
                        }
                        break;
                        // More cases as necessary
                    default:
                        Debug.WriteLine("Unknown property " + property);
                        break;
                }
            }
