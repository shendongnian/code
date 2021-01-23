    public class AffinitasClientRoot
    {
        [XmlArray("customerList", Namespace="")] // here!!!!
        [XmlArrayItem("customer")]
        public AffinitasClient[] Clients { get; set; }
    }
