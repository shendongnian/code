    	    // Creating a custom formatter for a TcpChannel sink chain.
			BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
			BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
			provider.TypeFilterLevel = TypeFilterLevel.Full;
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("typeFilterLevel", "Full");
			dict.Add("port", "0");
			ChannelServices.RegisterChannel(new TcpChannel(dict, clientProvider, provider), false);
