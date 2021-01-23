    public sealed class FakeMessageInspector : IClientMessageInspector
    {
        #region IClientMessageInspector Members
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (reply.IsFault)
            { reply = new FakeMessage(reply.Version, (string)correlationState); }
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return request.Headers.Action + "Response";
        }
        #endregion
    }
