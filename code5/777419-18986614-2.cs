    using System.Xml.Linq;
    try
    {
        var xdoc = XDocument.Load(path_to_xml);
    }
    catch (XmlException e)
    {
        // xml is invalid     
    }
