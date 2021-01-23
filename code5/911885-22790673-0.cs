    public class Person
    {
        public string personName;
        public string personEmail;
        public string personReports;
    }
    
    public class People
    {
        [XmlElement("Person")]
        public List<Person> Persons;
    }
