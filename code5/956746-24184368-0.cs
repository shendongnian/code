    public class SerializationModel
    {
        public int Id { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }
        [JsonExtensionData]
        public IDictionary<string, JToken> Properties { get; set; }
    }
    class Model
    {
        public int Id { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }
        public Dictionary<string, string[]> Properies { get; set; }
    }
    [Test]
    public void DeserializeTest()
    {
        string data = File.ReadAllText("data.txt");
        SerializationModel serializationModel = JsonConvert.DeserializeObject<SerializationModel>(data);
        Model model = new Model
        {
            Id = serializationModel.Id,
            Foo = serializationModel.Foo,
            Bar = serializationModel.Bar,
            Properies = serializationModel.Properties.ToDictionary(item => item.Key,pair => pair.Value.ToObject<string[]>())
        };
    }
