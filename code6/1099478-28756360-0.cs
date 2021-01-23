    public class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("YourXmlFile.xml");
            RootElement root = new RootElement(doc.Elements().FirstOrDefault());
            foreach (XElement item in root.GetInstances())
            {
                //--Your logic for adding the fields you want
            }
            Console.ReadLine();
        }
    }
    public class RootElement
    {
        public List<XElement> childElements { get; set; }
        public RootElement(XElement xElement)
        {
            childElements = new List<XElement>();
            foreach (XElement e in xElement.Elements())
            {
                childElements.Add(e);
            }
        }
        public List<XElement> GetInstances()
        {
            List<XElement> instances = new List<XElement>();
            foreach (XElement item in childElements)
            {
                if (item.Name == "Btn")
                {
                    IEnumerable<XElement> elements = item.Elements();
                    XElement child = elements.FirstOrDefault(x => x.Name == "sText");
                    if (child != null)
                    {
                        if (child.Value == "Hold")
                        {
                            instances.Add(item);
                        }
                    }
                }
            }
            return instances;
        }
    }
