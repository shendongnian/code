    /// <summary>
    /// Represents a message inspector object that can be added to the <c>MessageInspectors</c> collection to view or modify messages.
    /// </summary>
    public class VersionCheckMessageInspector : IClientMessageInspector
    {
        /// <summary>
        /// Enables inspection or modification of a message before a request message is sent to a service.
        /// </summary>
        /// <param name="request">The message to be sent to the service.</param>
        /// <param name="channel">The WCF client object channel.</param>
        /// <returns>
        /// The object that is returned as the <paramref name="correlationState " /> argument of
        /// the <see cref="M:System.ServiceModel.Dispatcher.IClientMessageInspector.AfterReceiveReply(System.ServiceModel.Channels.Message@,System.Object)" /> method.
        /// This is null if no correlation state is used.The best practice is to make this a <see cref="T:System.Guid" /> to ensure that no two
        /// <paramref name="correlationState" /> objects are the same.
        /// </returns>
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Add(new VersionMessageHeader());
            return null;
        }
        /// <summary>
        /// Enables inspection or modification of a message after a reply message is received but prior to passing it back to the client application.
        /// </summary>
        /// <param name="reply">The message to be transformed into types and handed back to the client application.</param>
        /// <param name="correlationState">Correlation state data.</param>
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var serverVersion = string.Empty;
            var idx = reply.Headers.FindHeader(VersionMessageHeader.HeaderName, VersionMessageHeader.HeaderNamespace);
            if (idx >= 0)
            {
                var versionReader = reply.Headers.GetReaderAtHeader(idx);
                while (versionReader.Name != "ServerVersion"
                       && versionReader.Read())
                {
                    serverVersion = versionReader.ReadInnerXml();
                    break;
                }
            }
            ValidateServerVersion(serverVersion);
        }
        private static void ValidateServerVersion(string serverVersion)
        {
            // TODO...
        }
    }
    public class VersionMessageHeader : MessageHeader
    {
        public const string HeaderName = "VersionSoapHeader";
        public const string HeaderNamespace = "<your namespace>";
        private const string VersionElementName = "ClientVersion";
        public override string Name
        {
            get { return HeaderName; }
        }
        public override string Namespace
        {
            get { return HeaderNamespace; }
        }
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteElementString(
                VersionElementName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }
