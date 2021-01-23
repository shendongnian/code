    var httpBinding = new BasicHttpBinding()
    {
        Security = new BasicHttpSecurity()
        {
            Mode = BasicHttpSecurityMode.TransportCredentialOnly,
            Message = new BasicHttpMessageSecurity() { ClientCredentialType = BasicHttpMessageCredentialType.UserName },
            Transport = new HttpTransportSecurity() { ClientCredentialType = HttpClientCredentialType.Windows }
        }
    };
    ChannelFactory<RecordFindSingle> factory = new ChannelFactory<RecordFindSingle>(httpBinding, new EndpointAddress("http://Server02/RecordFindSingle/RecordFindSingle.svc"));
    var channel = factory.CreateChannel();
    channel.FindSingleRecord();
