    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                CustomerName = "Bubba Gump Shrimp Company",
                CustomerNumber = "BG60938"
            };
            Console.WriteLine("--- Using JsonProperty names ---");
            Console.WriteLine(Serialize(foo, false));
            Console.WriteLine();
            Console.WriteLine("--- Ignoring JsonProperty names ---");
            Console.WriteLine(Serialize(foo, true));
        }
        static string Serialize(object obj, bool useLongNames)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            if (useLongNames)
            {
                settings.ContractResolver = new LongNameContractResolver();
            }
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
    class Foo
    {
        [JsonProperty("cust-num")]
        public string CustomerNumber { get; set; }
        [JsonProperty("cust-name")]
        public string CustomerName { get; set; }
    }
    class LongNameContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // Let the base class create all the JsonProperties using the short names
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
            // Now inspect each property and replace the short name with the real property name
            foreach (JsonProperty prop in list)
            {
                prop.PropertyName = prop.UnderlyingName;
            }
            // That's all we need to do; return the list
            return list;
        }
    }
