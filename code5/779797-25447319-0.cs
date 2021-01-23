    namespace v1
    {
        public class c
        {
            public bool Included { get; set; }
        }
    }
    namespace v2
    {
        public class c
        {
            [XmlElement("Included")]
            public bool IsIncluded { get; set; }
        }
    }
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                StringWriter sw = new StringWriter();
                new XmlSerializer(typeof(v1.c)).Serialize(sw, new v1.c{ Included=true} );
                StringReader sr = new StringReader( sw.ToString() );
                v2.c cc = (v2.c)new XmlSerializer(typeof(v2.c)).Deserialize(sr);
                Debug.Assert(cc.IsIncluded);
        }
    }
}
