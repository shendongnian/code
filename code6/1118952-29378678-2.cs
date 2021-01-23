    public class MyObject
    {
        [XmlElement("type")] //from your sample code route,person all go here
        public string objType
        {
            get;
            set;
        }
        [XmlElement("address")]
        public string personAddr
        {
            get;
            set;
        }
        [XmlElement("phone")]
        public string personPhone
        {
            get;
            set;
        }
    }
