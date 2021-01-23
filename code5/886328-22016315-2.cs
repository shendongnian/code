    //end point setup
    System.ServiceModel.EndpointAddress EndPoint = new System.ServiceModel.EndpointAddress("http://Domain:port/Class/Method");
    System.ServiceModel.EndpointIdentity EndpointIdentity = default(System.ServiceModel.EndpointIdentity);
    //binding setup
    System.ServiceModel.BasicHttpBinding binding = default(System.ServiceModel.BasicHttpBinding);
    binding.TransferMode = TransferMode.Streamed;
    //add settings
    binding.MaxReceivedMessageSize = int.MaxValue;
    binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
    binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
    binding.ReaderQuotas.MaxDepth = int.MaxValue;
    binding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
    binding.MaxReceivedMessageSize = int.MaxValue;
    binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
    binding.MessageEncoding = WSMessageEncoding.Text;
    binding.TextEncoding = System.Text.Encoding.UTF8;
    binding.MaxBufferSize = int.MaxValue;
    binding.MaxBufferPoolSize = int.MaxValue;
    binding.MaxReceivedMessageSize = int.MaxValue;
    binding.SendTimeout = new TimeSpan(0, 10, 0);
    binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
    //setup for custom binding
    System.ServiceModel.Channels.CustomBinding CustomBinding = new System.ServiceModel.Channels.CustomBinding(binding);
