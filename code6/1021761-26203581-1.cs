    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>
            {
                new Person {Name = "Larry", Age = "42", Gender = "M"},
                new Person {Name = "Steve", Age = "32", Gender = "M"},
                new Person {Name = "Nancy", Age = "22", Gender = "F"},
            };
            DataContractJsonSerializer ser = 
                new DataContractJsonSerializer(typeof(List<Person>));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, list);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine(sr.ReadToEnd());
        }
    }
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public string Gender { get; set; }
    }
