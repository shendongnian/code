    private HttpRequestMessageProperty GetHttpRequestMessageProperty(Message request)
    {
        if (!request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
        {
            request.Properties.Add(HttpRequestMessageProperty.Name, new HttpRequestMessageProperty());
        }
    
        return request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
    }
