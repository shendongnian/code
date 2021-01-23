    ChannelFactory<ServiceContract> factory = null;
    
     try
     {
       BasicHttpBinding binding = new BasicHttpBinding();
       EndpointAddress address = new EndpointAddress("http://localhost:4684/Service1.svc");
       factory = new ChannelFactory<ServiceContract>(binding, address);
       ServiceContract channel = factory.CreateChannel();
       string resturnmessage = channel.YourMehtod("test");
                     
     }
     catch(Exception ex)
     {
    
     } 
