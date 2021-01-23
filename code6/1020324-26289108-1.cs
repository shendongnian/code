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
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new KvpConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(root, settings);
            Console.WriteLine(json);
        }
    }
    public class Record
    {
        public string Name { get; set; }
        public KeyValuePair<string, object> Details { get; set; }
    }
