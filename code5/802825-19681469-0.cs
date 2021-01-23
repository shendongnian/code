    using System.Linq;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var xDoc = XDocument.Load("input.xml");
            xDoc.Descendants()
                .Where(d => 
                    d.Name.LocalName == "line_item" && 
                    d.Elements().Count() == 0)
                .ToList()
                .ForEach(e => e.Remove());
            // TODO: 
            //xDoc.Save(savePath);
        }
    }
