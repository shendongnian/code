    protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
    {
        writer.WriteStartElement("wsse", "BinarySecurityToken", Namespace);
        writer.WriteAttributeString("ValueType", "Bibble");
        writer.WriteAttributeString("EncodingType", "wsse:Base64Binary");
        writer.WriteValue("Fish");//write Fish
        writer.WriteEndElement();
    }
