    class Program
        {
            static void Main(string[] args)
            {
                const string xml = @"<ns:MyObject12 xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:ns1='http://example.com/xsd/example11' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:ns='http://www.example.com/xsd/MyObject12'><Status xmlns='some:stuff'><StatusCode>0</StatusCode></Status></ns:MyObject12>";
                var myObject12 = Deserialize<MyObject12>(xml, "http://www.example.com/xsd/MyObject12");
            }
    
            public static T Deserialize<T>(string xml, string defaultNamespace)
            {
                var serializer = new XmlSerializer(typeof(T), defaultNamespace);
                object obj;
                using (var stringReader = new StringReader(xml))
                {
                    obj = serializer.Deserialize(stringReader);
                    stringReader.Close();
                }
                return (T)obj;
            }
    
    
        }
    
        [Serializable]
        public class MyObject12
        {
            [XmlElement]
            public int StatusCode { get; set; }
        }
