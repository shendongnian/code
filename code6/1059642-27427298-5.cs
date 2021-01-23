    namespace XMLSerializationDemo
    {
        /// <summary>
        /// A container that contains properties relevant to a RUBI Object
        /// </summary>
        [Serializable]
        public class RUBIObject
        {
            [XmlAttribute]
            public Guid ID { get; set; }
    
            [XmlAttribute]
            public string Name { get; set; }
    
            [XmlAttribute]
            public string Description { get; set; }
    
            [XmlAttribute]
            public DateTime CreatedOn { get; set; }
        }
    }
