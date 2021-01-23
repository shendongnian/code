        [XmlType("Customer")]
        public class MyClass
        {
            [XmlElement("CustId")]
            public int Id { get; set; }
            [XmlElement("CustName")]
            public string Name { get; set; }
        }
