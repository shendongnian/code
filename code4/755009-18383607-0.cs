    public HttpResponseMessage Get()
    {
        XDocument xDoc = GetXMLDocument();
        var response = this.Request.CreateResponse(
            HttpStatusCode.OK, 
            xDoc.ToString(), 
            this.Configuration.Formatters.XmlFormatter
        );
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = "statistics.xml"
        };
        response.Headers.Add("Publisher", "Bill John");
        return response;
    }
