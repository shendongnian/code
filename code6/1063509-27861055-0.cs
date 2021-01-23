    public class ClientMessageInspector : System.ServiceModel.Dispatcher.IClientMessageInspector
    {
        #region IClientMessageInspector Members
  
         public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
         {
  
         }
         public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
         {
             CustomMessageHeader header = new CustomMessageHeader();
             request.Headers.Add(header);
             return null;
         }
         #endregion
     }
    /// <summary>
    /// Represents a custom message header.
    /// </summary>
    public class CustomMessageHeader : MessageHeader
    {
        private const string HeaderName = "CustomHeader";
        private const string HeaderNamespace = "";
        /// <summary>
        /// Gets the name of the message header.
        /// </summary>
        /// <returns>The name of the message header.</returns>
        public override string Name
        {
            get { return HeaderName; }
        }
        /// <summary>
        /// Gets the namespace of the message header.
        /// </summary>
        /// <returns>The namespace of the message header.</returns>
        public override string Namespace
        {
            get { return HeaderNamespace; }
        }
        /// <summary>
        /// Called when the header content is serialized using the specified XML writer.
        /// </summary>
        /// <param name="writer">
        /// An <see cref="T:System.Xml.XmlDictionaryWriter" /> that is used to serialize the header contents.
        /// </param>
        /// <param name="messageVersion">
        /// The object that contains information related to the version of SOAP associated with a message and its exchange.
        /// </param>
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteElementString("certificate", "JgsJSP6Ql8f........");
        }
    }
