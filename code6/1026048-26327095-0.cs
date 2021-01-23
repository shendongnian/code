    var doc = new System.Xml.XmlDocument();
    // strXml is the string containing your XML from XMLData.Text
    doc.LoadXml(strXml);
    // Find the node by an XPath expression
    var l2cr3 = (XmlElement) doc.SelectSingleNode("levels/level[name='Level 2']/crystal03");
    // Update it
    l2cr3.InnerText = "true";
    // Update the string in memory
    var sbOut = new System.Text.StringBuilder ();
    using (var writer = XmlWriter.Create(sbOut)) {
        doc.Save (writer);
    }
    strXml = sbOut.ToString ();
