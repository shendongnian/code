    [HttpGet]
    public HttpResponseMessage GetHtmlFromXslt()
    {
        var response = new HttpResponseMessage();
        response.Content = new StringContent(GetHtmlFromXmlAndXslt());
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
        return response;
    } 
