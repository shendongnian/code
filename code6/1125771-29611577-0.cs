        class Cat
        {
            public Cat(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; private set; }
            
            [DefaultValue(5)]            
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public int Age { get; private set; }
        }
        static void Main(string[] args)
        {
            string json = "{\"name\":\"mmmm\"}";
            Cat cat = JsonConvert.DeserializeObject<Cat>(json);
            Console.WriteLine("{0} {1}", cat.Name, cat.Age);
        }
