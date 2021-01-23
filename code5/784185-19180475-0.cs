    public IRestResponse<TResource> Get<TResource>(Uri uri, IDictionary<string, string> headers)
        where TResource : new()
    {
        if (typeof(TResource) == typeof(object)) 
        {
            throw new Exception("Use the dynamic one");
        }
    
        var request = this.GetRequest(uri, headers);
    
        return request.GetResponse<TResource>();
    }
