    using (var response = await _httpClient.SendAsync(request))
    {
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Unexpected status: " +
                 response.StatusCode.ToString() + " for the resource Uri " +
                 resourceUri);
        }
    
        var msg = new HttpResponseMessage(HttpStatusCode.OK);
        msg.Content = response.Content;
    
        response.Content = null; //<-- New line here
    
        return msg;
    }
