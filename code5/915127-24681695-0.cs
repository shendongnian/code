        protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            base.OnWriteStartHeader(writer, messageVersion);
        }
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteStartElement("xx");
            writer.WriteXmlAttribute("xmlns", "http://xx");
            writer.WriteString("xx");
            writer.WriteEndElement();
                    }
