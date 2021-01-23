    class Program
    {
        static void Main(string[] args)
        {
            X x = new X();
            x.CodeList = new List<string>() {"test", "test1"};
            var xml = new XmlSerializer(typeof (X));
            TextWriter writer = new StreamWriter("test.xml");
            xml.Serialize(writer,x);
            writer.Close();
        }
    }
    public class X
    {
        [XmlArrayItem("Code")]
        public List<string> CodeList { get; set; } 
    }
