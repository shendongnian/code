    public class Color
    {
        [XmlText]
        public string Name { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Color> colorlist = new List<Color>();
            colorlist.Add(new Color() { Name = "red", Type = "brush" });
            colorlist.Add(new Color() { Name = "blue", Type = "spray" });
            XmlWriterSettings xws = new XmlWriterSettings();            
            xws.OmitXmlDeclaration = true;
            xws.Encoding = Encoding.UTF8;
            xws.Indent = true;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            StringBuilder output = new StringBuilder();
            using(var wr = XmlWriter.Create(output, xws))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Color>), new XmlRootAttribute("ColorsList"));
                ser.Serialize(wr, colorlist, ns);
            }
            Console.WriteLine(output.ToString());
            Console.ReadLine();
        }
    }
