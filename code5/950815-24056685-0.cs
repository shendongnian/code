    public class MyTokenHandler : SessionSecurityTokenHandler
    {
        public override void WriteToken(XmlWriter writer, SecurityToken token)
        {
            SessionSecurityToken sessionSecurityToken = token as SessionSecurityToken;
            sessionSecurityToken.IsReferenceMode = true;
            string ns = "http://schemas.xmlsoap.org/ws/2005/02/sc";
            string localName = "SecurityContextToken";
            string localName2 = "Identifier";
            XmlDictionaryWriter xmlDictionaryWriter;
            if (writer is XmlDictionaryWriter)
            {
                xmlDictionaryWriter = (XmlDictionaryWriter)writer;
            }
            else
            {
                xmlDictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
            }
            xmlDictionaryWriter.WriteStartElement(localName, ns);
            xmlDictionaryWriter.WriteElementString(localName2, ns, sessionSecurityToken.ContextId.ToString());
            xmlDictionaryWriter.WriteEndElement();
            xmlDictionaryWriter.Flush();
        }
    }
