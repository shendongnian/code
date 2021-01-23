    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""prop1"": 142,
                ""prop2"": ""Some description"",
                ""object_prop"": {
                    ""abc"": 2,
                    ""def"": {
                        ""foo"": ""hello"",
                        ""bar"": 4
                    }
                },
                ""prop3"": 3.14
            }";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            JObject jo = JObject.Parse(json);
            foreach (JProperty prop in jo.Properties())
            {
                if (prop.Value.Type == JTokenType.Array || 
                    prop.Value.Type == JTokenType.Object)
                {
                    // JSON string for complex object
                    dict.Add(prop.Name, prop.Value.ToString(Formatting.None));  
                }
                else
                {
                    // primitive value converted to string
                    object value = ((JValue)prop.Value).Value;  
                    dict.Add(prop.Name, value != null ? value.ToString() : null);
                }
            }
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine(kvp.Key + " = " + kvp.Value);
            }
        }
    }
