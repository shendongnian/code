	using (var serviceHost = new ServiceHost(typeof(MyService)))
	{
		var endpoint = serviceHost.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "http://localhost:9000");
		serviceHost.Open();
		Console.WriteLine("Open for business");
		Console.ReadLine();
		serviceHost.Close();
	}
