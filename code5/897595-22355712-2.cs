    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company
            {
                CompanyName = "Initrode",
                Boss = new Person { FirstName = "Head", LastName = "Honcho" },
                Employees = new List<Person>
                {
                    new Person { FirstName = "Joe", LastName = "Schmoe" },
                    new Person { FirstName = "John", LastName = "Doe" }
                }
            };
            string json = JsonConvert.SerializeObject(company, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
    class Company
    {
        public string CompanyName { get; set; }
        public Person Boss { get; set; }
        public List<Person> Employees { get; set; }
    }
    [JsonConverter(typeof(ToStringJsonConverter))]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() 
        { 
            return string.Format("{0} {1}", FirstName, LastName); 
        }
    }
