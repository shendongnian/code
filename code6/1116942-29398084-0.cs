    string sharedCookie = string.Empty;
    using (MyClient client = new MyClient())
    {
        client.RequestThatContainsCookieValue();
        // This gets the response context
        HttpResponseMessageProperty response = (HttpResponseMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
        sharedCookie = response.Headers["Set-Cookie"];
        // Create a new request property
        HttpRequestMessageProperty request = new HttpRequestMessageProperty();
        // And add the cookie to the Header
        request.Headers["Cookie"] = sharedCookie;
        // Add the new request properties to the outgoing message
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = request;
        var response = client.ThisCallPassesTheCookieInTheHeader();
    }
