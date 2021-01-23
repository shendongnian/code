    public static void TestLoginAndGetData()
    {
        var sharedCookie = string.Empty;
		using (var client = new YourClient())
		using (new OperationContextScope(client.InnerChannel))
		{
		    client.Login("username", "password");
				
			// get the cookie from the response
			HttpResponseMessageProperty response = (HttpResponseMessageProperty)
				OperationContext.Current.IncomingMessageProperties[
				HttpResponseMessageProperty.Name];
			sharedCookie = response.Headers["Set-Cookie"];
				
			// add it to the request
			HttpRequestMessageProperty request = new HttpRequestMessageProperty();
			request.Headers["Cookie"] = sharedCookie;
			OperationContext.Current.OutgoingMessageProperties[
				HttpRequestMessageProperty.Name] = request;
			var result = client.GetData();
				
			Console.WriteLine(result);
		}
    }
