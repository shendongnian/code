    try
    {
        var client = new RestClient(_configuration.ServerUrl);
        var request = new RestRequest
        {
            Resource = _configuration.SomeUrl,
            Method = Method.POST
        };
    
        var response = client.Execute(request);
        if (response.ErrorException != null)
        {
            throw response.ErrorException;
        }
    }
    catch (WebException ex)
    {
        // TODO: check ex.Status, if it matches one of needed conditions.
    } 
