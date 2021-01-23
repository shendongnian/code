    Uri ServiceHostURI = new Uri(sURL);
    //my functional class is HostInterface
    ServiceHost ServiceHost = new ServiceHost(typeof(HostInterface), ServiceHostURI);
    EndpointAddress ServiceHostEndPoint = new EndpointAddress(ServiceHostURI);
    BasicHttpBinding b = default(BasicHttpBinding);
    CustomBinding binding = default(CustomBinding);
    
    //create first binding
    b = new BasicHttpBinding(BasicHttpSecurityMode.None);
    b.TransferMode = TransferMode.Buffered;
    b.MaxReceivedMessageSize = int.MaxValue;
    b.MessageEncoding = WSMessageEncoding.Text;
    b.TextEncoding = System.Text.Encoding.UTF8;
    //binding timeoutsettings
    dynamic specialTimeSpan = new TimeSpan(0, 30, 0);
    b.CloseTimeout = specialTimeSpan;
    b.ReceiveTimeout = specialTimeSpan;
    b.SendTimeout = specialTimeSpan;
    b.OpenTimeout = specialTimeSpan;
    b.ReaderQuotas = objReadQuotas;
    //create custom binding
    binding = new CustomBinding(b);
    //create and add behavior
    ServiceMetadataBehavior mb = new ServiceMetadataBehavior();
    ServiceHost.Description.Behaviors.Add(mb);
    mb.HttpsGetEnabled = true;
    mb.HttpGetEnabled = false;
    ServiceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,    MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");
     //here we open the end point
     ServiceHost.Open();
     // here we loop and monitor
     while (true) {
	
  	    //broken connection case
   	    if (ServiceHost.State != CommunicationState.Opened) {
   	          throw new Exception("Host failed.");
   	   		//dump from loop and throw error
   	   		break; 
   	    }
	 
  	     Threading.Thread.Sleep(c_SleepTime);
   	    //sleep 1 second before going trying next
     }
