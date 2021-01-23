    public class TestData {
            public string Name { get; set; }
            public string FullName { get; set; }
            public string Address { get; set; }
            public int PostalCode { get; set; }
    
            public TestData() {
                
            }
            public TestData(string name, string fullName, string address, int postalCode) {
                Name = name;
                FullName = fullName;
                Address = address;
                PostalCode = postalCode;
            }
        }
    
        public static class Program
        {
            
            public static string Serializer(object o)
            {
                var x = new XmlSerializer(o.GetType());
                var writer = new StringWriter();
                var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { OmitXmlDeclaration = true });
                var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                x.Serialize(xmlWriter, o, emptyNs);
                return writer.ToString();
            }
    
            public static string Serializer<T>(T o)
            {
                var x = new XmlSerializer(typeof(T));
                var writer = new StringWriter();
                var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { OmitXmlDeclaration = true });
                x.Serialize(xmlWriter, o, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
                return writer.ToString();
            } 
    
            public static void Main(string[] args) {
                Random rand = new Random();
                const int numberOfCycles = 1000000;
    
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < numberOfCycles; i++) {
                    object data = new TestData("", "", "", rand.Next());
                    Serializer(data);
                }
                watch.Stop();
    
                Console.WriteLine(string.Format("Through object:{0}", watch.ElapsedMilliseconds));
    
                watch.Restart();
                for (int i = 0; i < numberOfCycles; i++) {
                    Serializer(new TestData("", "", "", rand.Next()));
                }            
                watch.Stop();
                Console.WriteLine(string.Format("Through generic:{0}", watch.ElapsedMilliseconds));
    
                Console.ReadLine();
            }
        }
