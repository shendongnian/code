    public T Execute<T>(RestRequest request) where T : new()
    {
        var client = new RestClient(GetHost());
        if (AuthToken != null)
            client.Authenticator = new ShopifyAuthenticator(AuthToken);
    
        var result = client.Execute<T>(request);
    
        if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            throw new ShopifyUnauthorizedException(result.StatusDescription);
    
        if (result.ErrorException != null)
        {
            const string message = "Error retrieving response.  Check inner details for more information.";
            throw new ShopifyException(message, result.ErrorException);
        }
    
        return result.Data;
    }
    public string GetHost()
    {
        return Uri.UriSchemeHttps + Uri.SchemeDelimiter + Store + _shopifyHost;
    }
