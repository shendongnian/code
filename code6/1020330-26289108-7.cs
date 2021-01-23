    class Program
    {
        static void Main(string[] args)
        {
            var root = new Record
            {
                Name = "Root",
                Details = new KeyValuePair<string, object>("TestSerialization", 
                    new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("IsChild", true),
                        new KeyValuePair<string, object>("Child1", "Another KV pair")
                    })
            };
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(
                new List<JavaScriptConverter> { new KvpJavaScriptConverter() });
            string json = serializer.Serialize(root);
            Console.WriteLine(json);
        }
    }
