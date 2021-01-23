    using (new OperationContextScope((IClientChannel)client))
    {
       HttpRequestMessageProperty requestProperty = new HttpRequestMessageProperty();
       string credentials = string.Format("{0}:{1}", _username, _password);
       requestProperty.Headers["Authorization"] = string.Format("Basic {0}", Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(credentials)));
       OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestProperty;
       data = client.GetData1();
    }
