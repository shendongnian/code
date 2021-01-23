    //uncomment for serialization
    //#define serialize
    
    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace TestSerializer
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    #if serialize
    
                SomeClass some = new SomeClass();
                some.SomeString = "abc";
    
                XmlSerializer serializer = new XmlSerializer(some.GetType());
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, some);
                    File.WriteAllText("D:\\test.xml", writer.ToString());
                }
    #else
                XmlSerializer serializer = new XmlSerializer(typeof(SomeClass));
                using (StringReader reader = new StringReader(File.ReadAllText("D:\\test.xml")))
                {
                    var o = serializer.Deserialize(reader) as SomeClass;
                    if (o != null)
                        Console.WriteLine(o.SomeInt);
                }
                Console.ReadKey();
    #endif
            }
        }
    
    
    
    #if serialize
    
        [Serializable]
        public class SomeClass
        {
            public SomeClass() { }
            public string SomeString { get; set; }
        }
    #else
    
        [Serializable]
        public class SomeClass
        {
            public SomeClass() { }
            private int someInt = 10;
    
            
            public string SomeString { get; set; }
            public int SomeInt
            {
                get { return someInt; }
                set { someInt = value; }
            }
        }
    #endif
    }
