    using System.Xml.Linq;
    using System.Xml.XPath;
    var inDoc = XElement.Parse(i);
    var metaDoc = XElement.Parse(m);
    inDoc.XPathSelectElement("//Body/MetaDataSet").ReplaceWith(metaDoc);
