	var client = new ETap.MessagingServiceClient();
	string sessionEndpoint = client.login(username, password);
	int attempts = 0;
	while (!String.IsNullOrEmpty(sessionEndpoint))
	{
		if (attempts++ > 10)
			throw new Exception("ETapestry failed to provide a final endpoint.");
		client = new ETap.MessagingServiceClient("ETap", sessionEndpoint);
		sessionEndpoint = client.login(username, password);
	}
