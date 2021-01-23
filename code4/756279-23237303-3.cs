    public class CookieMessageInspector : IClientMessageInspector
    {
        private CookieContainer cookieCont;
        public CookieMessageInspector(CookieContainer cookieCont)
        {
            this.cookieCont = cookieCont;
        }
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply,
            object correlationState) 
        {
            object obj;
            if (reply.Properties.TryGetValue(HttpResponseMessageProperty.Name, out obj))
            {
                HttpResponseMessageProperty httpResponseMsg = obj as HttpResponseMessageProperty;
                if (!string.IsNullOrEmpty(httpResponseMsg.Headers["Set-Cookie"]))
                {
                    cookieCont.SetCookies((Uri)correlationState, httpResponseMsg.Headers["Set-Cookie"]);
                }
            }
        }
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request,
            System.ServiceModel.IClientChannel channel)
        {
            object obj;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out obj))
            {
                HttpRequestMessageProperty httpRequestMsg = obj as HttpRequestMessageProperty;
                SetRequestCookies(channel, httpRequestMsg);
            }
            else
            {
                var httpRequestMsg = new HttpRequestMessageProperty();
                SetRequestCookies(channel, httpRequestMsg);
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMsg);
            }
            return channel.RemoteAddress.Uri;
        }
        private void SetRequestCookies(System.ServiceModel.IClientChannel channel, HttpRequestMessageProperty httpRequestMessage)
        {
            httpRequestMessage.Headers["Cookie"] = cookieCont.GetCookieHeader(channel.RemoteAddress.Uri);
        }
    }
