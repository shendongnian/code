    static void Main()
            {
                var objs = new object[] { new A { P1 = 3 }, new B { P2 = 4 } };
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    NullValueHandling = NullValueHandling.Ignore,
                    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                    ContractResolver = new DtoContractResolver(),
                };
                var serial = JsonSerializer.Create(settings);
                var jsonArray = new JArray();
                foreach (var obj in objs)
                {
                    if (obj != null && obj.GetType().IsSealed && obj.GetType().BaseType == typeof(object))
                        serial.TypeNameHandling = TypeNameHandling.None;
                    else
                        serial.TypeNameHandling = TypeNameHandling.Objects;
                    jsonArray.Add(JObject.FromObject(obj, serial));
                }
                var json = jsonArray.ToString(Formatting.None);
                Console.WriteLine(json);
                
                if (Debugger.IsAttached)
                    Console.ReadKey();
            }
