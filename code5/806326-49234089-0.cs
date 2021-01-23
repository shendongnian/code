                BasicHttpBinding myBinding = new BasicHttpBinding();
                EndpointAddress myEndpoint = new EndpointAddress("http://localhost:3283/Service1.svc");
    
                myBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                myBinding.MaxBufferSize = int.MaxValue;
                myBinding.MaxReceivedMessageSize = int.MaxValue;
              
                ChannelFactory<ITestAPI> myChannelFactory = new ChannelFactory<ITestAPI>(myBinding, myEndpoint);
    
                ITestAPI instance = myChannelFactory.CreateChannel();
              
                Test data = new Test();
                data.helloName = name;
                data= instance.GetMyName(data);
    
                myChannelFactory.Close();
