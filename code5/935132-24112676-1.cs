    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""OuterGroup"": {
                    ""ElementA"": {
                        ""$id"": ""1"",
                        ""data"": ""A""
                    },
                    ""ElementB"": {
                        ""$id"": ""2"",
                        ""data"": ""B""
                    }
                },
                ""OuterElement"": {
                    ""$ref"": ""1""
                }
            }";
            var root = (Dictionary<string, object>)DeserializePreservingReferences(json);
            var g = (Dictionary<string, object>)root["OuterGroup"];
            g.Remove("ElementA");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            settings.Formatting = Formatting.Indented;
            Console.WriteLine(JsonConvert.SerializeObject(root, settings));
        }
    }
