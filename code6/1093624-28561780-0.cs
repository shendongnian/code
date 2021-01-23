    using System.Xml.XPath;
    var xml = XElement.Load(xmlFile);
    //var xml = XElement.Parse(xmlString); //in case of loading from string
    var liceElement = xml.XPathSelectElement("//EmbeddedResource[@Include='lice.pccx']");
    liceElement.Remove();
    //liceElement.Parent.Remove(); //if you would like to remove the whole 'ItemGroup' 
    xml.Add(new XElement("ItemGroup",
            new XElement("EmbeddedResource",
                new XAttribute("Include", "licenses.licx"))));
    
    xml.ToString();
