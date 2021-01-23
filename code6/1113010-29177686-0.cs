    public sealed class FakeMessage : Message
    {
        #region Fields
        private MessageProperties properties;
        private MessageHeaders headers;
        #endregion
        #region Constructors
        public FakeMessage(MessageVersion version, string action)
        {
            this.headers = new MessageHeaders(version);
            this.headers.Action = action;
        }
        #endregion
        #region Message Members
        public override MessageHeaders Headers
        {
            get { return headers; }
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            throw new NotSupportedException();
        }
        public override MessageProperties Properties
        {
            get
            {
                if (this.properties == null)
                { properties = new MessageProperties(); }
                return properties;
            }
        }
        public override MessageVersion Version
        {
            get { return headers.MessageVersion; }
        }
        #endregion
    }
