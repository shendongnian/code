    using System.Xml.Serialization;
    namespace Serialization
    {
        public class ValuesGenerator
        {
            private const string XmlPath = "SPECIFY THE XML FULL PATH HERE";
        
            public List<Values> GetColumnInfo()
            {
                var serializer = new XmlSerializer(typeof(List<Values>));
                return (List<Values>)serializer.Deserialize(new StreamReader(XmlPath));
            }
        }
    }
