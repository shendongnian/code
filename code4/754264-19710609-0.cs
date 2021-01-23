    [HttpPost("csv")]
    public HttpResponseMessage GetCvsReport()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        var content = "12€;3;test";
        var encoding = Encoding.UTF8;
    
        response.Content = new StringContent(content, encoding , "text/csv");
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = yourfile.csv"
        };
    
        return response;
    }
