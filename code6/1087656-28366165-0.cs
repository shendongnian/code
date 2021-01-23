	    [TestMethod]
		public void ChangeEndpointAddressAtRuntime()
		{
		    var host = new ServiceHost(typeof(FileRepositoryService));
		    var serviceEndpoint = host.Description.Endpoints.First(e => e.Contract.ContractType == typeof (IFileRepositoryService));
		    var oldAddress = serviceEndpoint.Address;
		    Console.WriteLine("Curent Address: {0}", oldAddress.Uri);
		    var newAddress = "net.tcp://localhost:5001";
		    Console.WriteLine("New Address: {0}", newAddress);
		    serviceEndpoint.Address = new EndpointAddress(new Uri(newAddress), oldAddress.Identity, oldAddress.Headers);
		    Task.Factory.StartNew(() => host.Open());
		    var channelFactory = new ChannelFactory<IFileRepositoryService>(new NetTcpBinding("customTcpBinding"), new EndpointAddress(newAddress));
		    var channel = channelFactory.CreateChannel();
		    channel.Method();
		    (channel as ICommunicationObject).Close();
		    channelFactory = new ChannelFactory<IFileRepositoryService>(new NetTcpBinding("customTcpBinding"), oldAddress);
		    channel = channelFactory.CreateChannel();
		    bool failedWithOldAddress = false;
		    try
		    {
		        channel.Method();
		    }
		    catch (Exception e)
		    {
		        failedWithOldAddress = true;
		    }
		    (channel as ICommunicationObject).Close();
		    Assert.IsTrue(failedWithOldAddress);  
		}
