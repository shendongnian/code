    string words = "<node>it's my \"node\" & i like it<node><br/>test";
    using (XmlTextWriter writer= new XmlWriter.Create(@"c:\Task\task.xml", settings))
    {
        writer.WriteStartElement("Nodes");
        writer.WriteStartElement("sNode");
        writer.WriteElementString("Word", words);
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
