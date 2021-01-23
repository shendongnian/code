    using System.Xml.Serialization;
    namespace DemoApplication
    {
        public class NewDataSet
        {
            [XmlElement]
            public Table Table1 { get; set; }
        }
    }
    namespace DemoApplication
    {
        public class Table
        {
            public string Conact { get; set; }
        }
    }
