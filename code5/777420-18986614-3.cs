    using System.Xml.Linq; // include this in your using directives
    try
    {
        var xdoc = XDocument.Load(path_to_xml);
    }
    catch (XmlException e)
    {
        // xml is invalid     
    }
