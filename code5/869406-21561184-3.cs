    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Item"":
                {
                    ""Name"":""Apple"",
                    ""Id"":""4b7e9f9f-7a30-4f79-8e47-8b50ea26ddac"",
                    ""Size"":5,
                    ""Quality"":2
                }
            }";
            Item item = JsonConvert.DeserializeObject<Wrapper>(json).Item;
            Console.WriteLine("Name: " + item.Name);
            Console.WriteLine("Id: " + item.Id);
            foreach (KeyValuePair<string, object> kvp in item.CustomFields)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }
        }
    }
    public class Wrapper
    {
        public Item Item { get; set; }
    }
    class CrazyStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            // Reverse the string just for fun
            return new string(token.ToString().Reverse().ToArray());
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
