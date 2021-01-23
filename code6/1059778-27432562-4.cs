    [XmlTypeAttribute(AnonymousType = true)]
            public class CustomData
            {
                [XmlArray(ElementName = "Records")]
                [XmlArrayItem(ElementName = "record")]
                public List<Record> Records { get; set; }
    
                public C
