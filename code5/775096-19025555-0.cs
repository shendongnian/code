        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            string jsonText = SerializeJsonRequestParameters(parameters);
            // Compose message
            Message message = Message.CreateMessage(messageVersion, _clientOperation.Action);
            _address.ApplyTo(message);
            HttpRequestMessageProperty reqProp = new HttpRequestMessageProperty();
            reqProp.Headers[HttpRequestHeader.ContentType] = "application/json";
            reqProp.Method = "GET";
            message.Properties.Add(HttpRequestMessageProperty.Name, reqProp);
            UriBuilder builder = new UriBuilder(message.Headers.To);
            builder.Query = string.Format("jsonrpc={0}", HttpUtility.UrlEncode(jsonText));
            message.Headers.To = builder.Uri;
            message.Properties.Via = builder.Uri;
            return message;
        }
