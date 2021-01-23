    public class WebServiceSOAPExtension : SoapExtension
    {
        private Stream inwardStream;
        private Stream outwardStream;
        public override Stream ChainStream(Stream stream)
        {
            outwardStream = stream;
            inwardStream = new MemoryStream();
            return inwardStream;
        }
        public override object GetInitializer(Type serviceType)
        {
            return null;
        }
        
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
        public override void Initialize(object initializer)
        {
            return;
        }
        public override void ProcessMessage(System.Web.Services.Protocols.SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    RewriteResponse();
                    break;
                case SoapMessageStage.AfterSerialize:
                    RewriteRequest();
                    break;
            }
        }
        private void RewriteResponse()
        {
            string message;
            var streamReader = new StreamReader(outwardStream);
            var streamWriter = new StreamWriter(inwardStream);
            message = streamReader.ReadToEnd();
            streamWriter.Write(message);
            streamWriter.Flush();
            inwardStream.Position = 0;
        }
        private void RewriteRequest()
        {
            string message;
            XmlDocument xmlDoc = new XmlDocument();
            inwardStream.Position = 0;
            var streamReader = new StreamReader(inwardStream);
            var streamWriter = new StreamWriter(outwardStream);
            message = streamReader.ReadToEnd();
            xmlDoc.LoadXml(message);
            var bodyNode = xmlDoc.GetElementsByTagName("Body", "http://www.w3.org/2003/05/soap-envelope/")[0];
            var headerNode = xmlDoc.CreateElement("s", "Header", "http://www.w3.org/2003/05/soap-envelope/");
            var actionNode = xmlDoc.CreateElement("wsa", "Action", "http://www.w3.org/2004/12/addressing");
            actionNode.InnerText = "http://sampleserver.example/Action";
            headerNode.AppendChild(actionNode);
            bodyNode.ParentNode.InsertBefore(headerNode, bodyNode);
            message = xmlDoc.InnerXml;
            streamWriter.Write(message);
            streamWriter.Flush();
        }
    }
