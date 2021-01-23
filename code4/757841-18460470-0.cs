    XmlDocument doc = new XmlDocument();
    doc.PreserveWhitespace = true;
    doc.LoadXml(xml);
    XmlNodeList list = doc.GetElementsByTagName("Document");
    XmlElement node = (XmlElement)list[0];
    node.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        
    string s = node.OuterXml;
    // The XmlDsigC14NTransform will strip the UTF8 BOM
    using (MemoryStream msIn = new MemoryStream(Encoding.UTF8.GetBytes(s)))
    {
        XmlDsigC14NTransform t = new XmlDsigC14NTransform(true);
        t.LoadInput(msIn);
        using (var hash = new SHA256Managed())
        {
            byte[] digest = t.GetDigestedOutput(hash);
            string result = BitConverter.ToString(digest).Replace("-", String.Empty);
        }
    }
