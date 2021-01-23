    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer() {Email = "asd@asd.com", Test = "asdasd"};
            var a = Serialize(customer, false);
            var b = Serialize(customer, true);
            Console.WriteLine(a);
            Console.WriteLine(b);
            var desA = Deserialize<Customer>(a, false);
            var desB = Deserialize<Customer>(b, true);
            Console.WriteLine("TestA: {0}", desA.Test);
            Console.WriteLine("TestB: {0}", desB.Test);
        }
        static string Serialize(object obj, bool newNames)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            if (newNames)
            {
                settings.ContractResolver = new CustomNamesContractResolver();
            }
            return JsonConvert.SerializeObject(obj, settings);
        }
        static T Deserialize<T>(string text, bool newNames)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            if (newNames)
            {
                settings.ContractResolver = new CustomNamesContractResolver();
            }
            return JsonConvert.DeserializeObject<T>(text, settings);
        }
    }
    class CustomNamesContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            // Let the base class create all the JsonProperties 
            // using the short names
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
            // Now inspect each property and replace the 
            // short name with the real property name
            foreach (JsonProperty prop in list)
            {
                if (prop.UnderlyingName == "Test") //change this to your implementation!
                    prop.PropertyName = "Test" + 5;
            }
            return list;
        }
    }
    public class Customer
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        public string Test { get; set; }
    }
