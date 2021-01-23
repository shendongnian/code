    [XmlRoot("Employee", Namespace="")]
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [XmlElement("City")]
        public List<City> City { get; set; }
    }
    public class City
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CityName { get; set; }
    }
