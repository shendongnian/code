    class MyCollection : Collection<string>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return(null);
        }
    
        public void WriteXml(XmlWriter writer)
        {
            //// foreach (var item in Items)
                //// writer.Write...
        }
    
        public void ReadXml(XmlReader reader)
        {
            //// Items.Add(reader.Read...
        }
    }
