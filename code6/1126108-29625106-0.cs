    public class TestXML : IXmlSerializable
    {
        public String Label = "Hello";
        public Boolean Enable = true;
        public Int32 PosX = 12;
        public Int32 PosY = 34;
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            reader.ReadStartElement("model");
            if (reader.Name != "prop")
            { throw new InvalidOperationException(); }
            do
            {
                if (!reader.MoveToAttribute("name"))
                { throw new InvalidOperationException(); }
                string name = reader.Value;
                if (!reader.MoveToAttribute("value"))
                { throw new InvalidOperationException(); }
                switch (name)
                {
                    case "Label": Label = reader.Value; break;
                    case "Enable": Enable = XmlConvert.ToBoolean(reader.Value); break;
                    case "PosX": PosX = XmlConvert.ToInt32(reader.Value); break;
                    case "PosY": PosY = XmlConvert.ToInt32(reader.Value); break;
                }
            }
            while (reader.ReadToNextSibling("prop"));
            reader.ReadEndElement();
            reader.ReadEndElement();
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("model");
            WriteProperty(writer, "Label", Label);
            WriteProperty(writer, "Enable", XmlConvert.ToString(Enable));
            WriteProperty(writer, "PosX", XmlConvert.ToString(PosX));
            WriteProperty(writer, "PosY", XmlConvert.ToString(PosY));
            writer.WriteEndElement();
        }
        private void WriteProperty(XmlWriter writer, string name, string value)
        {
            writer.WriteStartElement("prop");
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("value", value);
            writer.WriteEndElement();
        }
    }
