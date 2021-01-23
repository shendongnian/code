    public class TrimmingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override bool CanRead { get { return true; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ((string)reader.Value).Trim();
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    // use like this to apply to all string fields:
    var p = JsonConvert.DeserializeObject<Person>(@"{ name: "" John "" }", new TrimmingConverter());
    Console.WriteLine("Name is: \"{0}\"", p.Name);
    // or like this to apply to certain fields only:
    class Person
    {
        [JsonProperty("name")]
        [JsonConverter(typeof(TrimmingConverter))] // <-- that's the important line
        public string Name { get; set; }
        [JsonProperty("other")]
        public string Other { get; set; }
    }
    var p = JsonConvert.DeserializeObject<Person>(@"{ name: "" John "", other: "" blah blah blah "" }");
    Console.WriteLine("Name is: \"{0}\"", p.Name);
    Console.WriteLine("Other is: \"{0}\"", p.Other);
    // outputs:
    Name is: "John"
    Other is: " blah blah blah "
