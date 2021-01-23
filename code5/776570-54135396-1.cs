    [Serializable]
    public class Customer
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
 
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Age")] public int Age { get; set; }
        public bool ShouldSerializeLastName()
        {
            return Age > 18; // Enter here only if it is XmlSerialize.
        }
    }
