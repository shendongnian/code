    public class StringXmlDataWriter : BodyWriter
    {
        private string data;
        public StringXmlDataWriter(string data)
            : base(false)
        {
            this.data = data;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteRaw(data);
        }
    }
    public void ProcessHeaders()
        {
            string headers = "<soapenv:Header xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\"> <wsa:MessageID>1337</wsa:MessageID> </soapenv:Header>";
            var headerXML = XElement.Parse(headers);
            foreach (var header in headerXML.Elements())
            {
                var message = Message.CreateMessage(OperationContext.Current.IncomingMessageVersion, header.Name.LocalName, new StringXmlDataWriter(header.ToString()));
                OperationContext.Current.OutgoingMessageHeaders.CopyHeadersFrom(message);
            }
        }
