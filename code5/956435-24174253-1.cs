    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Id = 2,
                Name = "Peter",
                Employer = new Company
                {
                    Id = 5,
                    Name = "Initech"
                }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CustomResolver("MyTypeName"),
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(p, settings);
            Console.WriteLine(json);
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Employer { get; set; }
    }
    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
