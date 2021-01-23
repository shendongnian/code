    public class MyObject : IXmlSerializable
    {
        public MyParam A { get; set; }
        public MyParam B { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
        public void WriteXml(XmlWriter writer)
        {
            //Call each properties "WriteAttribute" call.
            A.WriteAttribute(writer);
            B.WriteAttribute(writer);
        }
    }
    public class MyParam
    {
        string name;
        string stringVal;
        double doubleVal;
        
        public string Val
        {
            get
            {
                return stringVal;
            }
            set
            {
                stringVal = value;
                doubleVal = double.Parse(value);
            }
        }
        
        public double DoubleVal
        {
            get
            {
                return doubleVal;
            }
            set
            {
                doubleVal = value;
                stringVal = value.ToString();
            }
        }
        public MyParam(string name)
        {
            this.name = name;
            this.stringVal = string.Empty;
            this.doubleVal = double.NaN;
        }
        internal void WriteAttribute(XmlWriter writer)
        {
            writer.WriteAttributeString(name, stringVal);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyObject()
            {
                A = new MyParam("A"),
                B = new MyParam("B"),
            };
            test.A.Val = "1.2e5";
            test.B.Val = "2.0";
            var ser = new XmlSerializer(typeof(MyObject));
            var sb = new StringBuilder();
            using (var stream = new StringWriter(sb))
            {
                ser.Serialize(stream, test);
            }
            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
