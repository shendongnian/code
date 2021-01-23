    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
              ""collection1"": {
                ""item"": {
                  ""label"": ""A"",
                  ""value"": ""1""
                }
              },
              ""collection2"": {
                ""item"": [
                  {
                    ""label"": ""B"",
                    ""value"": ""2""
                  },
                  {
                    ""label"": ""C"",
                    ""value"": ""3""
                  }
                ]
              },
              ""collection3"": null
            }";
            JObject root = JObject.Parse(json);
            DumpItems(root, "collection1");
            DumpItems(root, "collection2");
            DumpItems(root, "collection3");
        }
        private static void DumpItems(JToken token, string collectionName)
        {
            JArray array = token[collectionName].ToJArray("item");
            Console.WriteLine("Count of items in " + collectionName + ": " + array.Count);
            foreach (JToken item in array)
            {
                Console.WriteLine(item["label"] + ": " + item["value"]);
            }
        }
    }
