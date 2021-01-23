        private static Message SendMessage(string id)
        {
            var body = new GetPolicyData {request =  new request{ REQ_POL_NBR = id }}; 
            var message = Message.CreateMessage(MessageVersion.Soap11, "http://Foo.bar.car/IPolicyService/GetPolicyData", body);
    // these headers would probably not be required, but added for completeness
            message.Headers.Add(MessageHeader.CreateHeader("Accept-Header", string.Empty, "application/xml+"));
            message.Headers.Add(MessageHeader.CreateHeader("Content-Type", string.Empty, "text/xml"));
            message.Headers.Add(MessageHeader.CreateHeader("FromSender", string.Empty, "DispatchMessage"));
            message.Headers.To = new System.Uri(@"http://localhost:5050/PolicyService.svc");
    
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                 MessageEncoding = WSMessageEncoding.Text,
                MaxReceivedMessageSize = int.MaxValue,
                SendTimeout = new TimeSpan(1, 0, 0),
                ReaderQuotas = { MaxStringContentLength = int.MaxValue, MaxArrayLength = int.MaxValue, MaxDepth = int.MaxValue }
            };
            message.Properties.Add("Content-Type", "text/xml; charset=utf-8");
            message.Properties.Remove("Accept-Encoding");
            message.Properties.Add("Accept-Header", "application/xml+");
    
            var cf = new ChannelFactory<IRequestChannel>(binding, new EndpointAddress(new Uri("http://localhost:5050/PolicyService.svc")));
    
            cf.Open();
            var channel = cf.CreateChannel();
            channel.Open();
    
            var result = channel.Request(message);
    
            channel.Close();
            cf.Close();
            return result;
        }
