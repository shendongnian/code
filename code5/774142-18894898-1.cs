    string words = "<node>it's my \"node\" & i like it<node><br/>test";
    using (XmlTextWriter xtw = new XmlTextWriter(@"c:\xmlTest.xml", Encoding.Unicode))
    {
        writer.WriteStartElement("Nodes");
        writer.WriteStartElement("sNode");
        writer.WriteElementString("Word", words);
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
