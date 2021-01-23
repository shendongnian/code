    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Id = 1,
                Field = "Value",
            };
            form.NestedObject = form;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new SerializationConverter() },
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            };
            string json = JsonConvert.SerializeObject(form, settings);
            Console.WriteLine(json);
        }
    } 
    class Form
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public Form NestedObject { get; set; }
    }
