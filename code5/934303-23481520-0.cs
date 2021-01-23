    [XmlRoot("Fruits")]
    public class Fruits
    {
        [XmlElement("AppleFruit")]
        public Apple[] Apples { get; set; }
        [XmlElement("OrangeFruit")]
        public Orange[] Oranges { get; set; }
    }
    [Serializable]
    [XmlInclude(typeof(Apple))]
    [XmlInclude(typeof(Orange))]
    public abstract class Fruit {
        public bool IsRotten { get; set; }
    }
    
    [Serializable]
    public class Apple : Fruit {
        public bool FellFarFromTree { get; set; }
    }
    
    [Serializable]
    public class Orange : Fruit {
        public int NumberOfSegments { get; set; }
    }
    public void XmlBlend(Fruits fruits) {
        using (var writer = new XmlTextWriter(@"c:\test\blended_fruits.xml", Encoding.UTF8)) {
            writer.Formatting = Formatting.Indented;
            
            var serializer = new XmlSerializer(typeof(Fruits));
            serializer.Serialize(writer, fruits);
        }
    }
