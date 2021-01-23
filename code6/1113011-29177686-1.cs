    public sealed class FakeMessageFormatter : IClientMessageFormatter
    {
        #region Fields
        private IClientMessageFormatter baseFormatter;
        private object defaultReturnValue;
        #endregion
        #region Construcotrs
        public FakeMessageFormatter(IClientMessageFormatter baseFormatter, Type returnType)
        {
            this.baseFormatter = baseFormatter;
            if (returnType.IsValueType && returnType != typeof(void))
            { this.defaultReturnValue = Activator.CreateInstance(returnType); }
        }
        #endregion
        #region IClientMessageFormatter Members
        public object DeserializeReply(Message message, object[] parameters)
        {
            if (message is FakeMessage)
            { return defaultReturnValue; }
            return baseFormatter.DeserializeReply(message, parameters);
        }
        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            return baseFormatter.SerializeRequest(messageVersion, parameters);
        }
        #endregion
    }
