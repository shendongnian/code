	var channel = ChannelFactory<IMyService>.CreateChannel(new BasicHttpBinding(), new EndpointAddress("http://localhost:9000"));
	var contextChannel = channel as IContextChannel;
	using (new OperationContextScope(contextChannel))
	{
		channel.MyMethod();
		var incommingHeaders = OperationContext.Current.IncomingMessageHeaders;
		var header = incommingHeaders.GetHeader<string>("headerFromMethod", "namespace");
		Console.WriteLine("Header from server: " + header);
	}
	
