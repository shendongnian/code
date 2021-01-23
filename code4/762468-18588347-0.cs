    public class Child : Parent, IXmlSerializable
    {
        public int Foo { get; set; }
        public Dictionary<string, int> Dictionary { get; set; }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Foo");
            writer.WriteValue(this.Foo);
            writer.WriteEndElement();
        }
        void ReadXml(XmlReader reader)
        {            
            var wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
            {
                return;
            }
            reader.ReadStartElement("Foo");
            this.Foo = reader.ReadContentAsInt();
            reader.ReadEndElement();
        }
    }
