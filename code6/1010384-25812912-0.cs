    using System.Xml.Linq;
    XDocument xDoc = XDocument.Parse(xmlString);
    xDoc.Root.Elements("annotation")
             .SelectMany(s => s.Elements("image")
                               .GroupBy(g => g.Attribute("location").Value)
                               .SelectMany(m => m.Skip(1))).Remove();
