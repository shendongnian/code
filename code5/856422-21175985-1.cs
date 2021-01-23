    namespace ConsoleApplication1
    {
    class Program
    {
        //private const string xmlPath = @"C:\Users\Jumast\Desktop\StackOverflowQuestion.xml";
        private const string xmlPath, // put the file path here
        static Body makeBody()
        {
            var instance1 = new MyType() { Category = Category.MyTypeA, Foo = "bar" };
            var instance2 = new MyType() { Category = Category.MyTypeB, Foo = "bar" };
			return new Body(){Instance1 = instance1, Instance2 = instance2};
        }
        static void serializeBody(Body body, string path)
        {
            var ser = new DataContractSerializer(body.GetType(), body.GetType().Name, "");
            using (var w = XmlWriter.Create(path, new XmlWriterSettings() { Indent = true }))
            {
                ser.WriteObject(w, body);
            }
        }
        static Body deseerializeBody(string xmlPath)
        {
			Body deserializedBody;
            var ser = new XmlSerializer(typeof(Body));
            using (Stream stream = File.OpenRead(xmlPath))
            {
                deserializedBody = (Body)ser.Deserialize(stream);
            }
            return deserializedBody;
        }
        static void writeBodyToConsole(Body body)
        {
            Console.WriteLine("Instance1: " + body.Instance1);
            Console.WriteLine("Instance2: " + body.Instance2);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
			serializeBody(makeBody(), xmlPath);
			writeBodyToConsole(deseerializeBody(xmlPath));
        }
    }
    public class Body : IXmlSerializable
    {
        #region Properties
        public MyType Instance1 { get; set; }
        public MyType Instance2 { get; set; }
        #endregion
        #region IXmlSerializable
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
			reader.ReadStartElement();
            Instance1 = new MyType(reader);
			Instance2 = new MyType(reader);
			reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
			Instance1.WriteXml(writer);
            Instance2.WriteXml(writer);
        }
        #endregion
    }
    public class MyType : IXmlSerializable
    {
        #region Fields
        private Category _category;
        #endregion
        #region Constructors
        public MyType()
        {
            _category = Category.nil;
            Foo = string.Empty;
        }
        public MyType(XmlReader reader) { ReadXml(reader);}
        #endregion
        #region Methods
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Foo = {0}", Foo));
            sb.Append(" , ");
            sb.Append(string.Format("Category = {0}", Category));
            return sb.ToString();
        }
        #endregion
        #region Properties
        public string Foo { get; set; }
        public Category Category
        {
            get { return this._category; }
            set { this._category = value; }
        }
        #endregion
        #region IXmlSerializable
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            Enum.TryParse(reader.Name, out _category);
            reader.Read();
            Foo = reader.ReadElementContentAsString("Foo", "");
			reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
			writer.WriteStartElement(this.Category.ToString(), "");
            writer.WriteElementString("Foo", Foo);
			writer.WriteEndElement();
        }
        #endregion
    }
	public enum Category
	{
		MyTypeA,
		MyTypeB,
		nil
	}
    }
