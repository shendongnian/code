    public HttpResponseMessage Get()
    {
        HttpResponseMessage response = new HttpResponseMessage();
    
        IContentNegotiator defaultNegotiator = this.Configuration.Services.GetContentNegotiator();
        ContentNegotiationResult negotationResult = defaultNegotiator.Negotiate(typeof(string), this.Request, this.Configuration.Formatters);
    
        response.Content = new ObjectContent<string>("Hello", negotationResult.Formatter, negotationResult.MediaType);
        return response;
    }
