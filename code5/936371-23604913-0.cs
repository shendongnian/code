    XElement xdoc = stripNS(XElement.Parse(node.NextSibling.OuterXml, LoadOptions.PreserveWhitespace));
                           XmlDocument xmlDoc = new XmlDocument();
                           using (XmlReader xmlReader = xdoc.CreateReader())
                           {
                               xmlDoc.Load(xmlReader);
                           }
    static XElement stripNS(XElement root)
               {
                   return new XElement(root.Name.LocalName, root.HasElements ? root.Elements().Select(el => stripNS(el)) : (object)root.Value);
               }
