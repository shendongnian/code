       string jsonInput = "Your json STRING";
    
                        Newtonsoft.Json.Linq.JContainer resp = (Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(jsonInput);
                        foreach (JObject str in resp)
                        {
                            JsonSerializer serializer = new JsonSerializer();
    
                            YourObject p = (YourObject)serializer.Deserialize(new JTokenReader(str), typeof(YourObject));
                            YourObjectAsListOfObject.Add(p);
                        }
