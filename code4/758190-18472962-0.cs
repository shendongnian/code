    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Linq;
    public static void Main(string[] args)
    {
        string sourceDir = @"C:\splitXML\results\XML\";
        string xmlDestDir = @"C:\results\XMLSorted\";
        string[] events = { "Creation", "Assignment", "Modification", "Repair", "RepairReview", "Termination", "Test" };
        Dictionary<string, XmlWriter> writers = events.ToDictionary(e => e, e => XmlWriter.Create(Path.Combine(xmlDestDir, e + "Uber.xml")));
            
        foreach(var writer in writers.Values)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("PCBDatabase");
        }
            
        foreach(var file in Directory.EnumerateFiles(sourceDir, "*.xml", SearchOption.AllDirectories)) //roughly 13k files
        {
            XDocument xd = XDocument.Load(file);    
            var actionEvents = from e in xd.Descendants("PCBDatabase").Elements() select e;
            string eventType = (from e in actionEvents.Elements() select e.Name.ToString()).First();
                
            foreach(XElement actionEvent in actionEvents)
            {
                actionEvent.WriteTo(writers[eventType]);
            }    
        }
            
        foreach(var writer in writers.Values)
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }            
    }
