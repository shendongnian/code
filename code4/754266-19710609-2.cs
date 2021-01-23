    [HttpPost("csv")]
    public HttpResponseMessage GetCvsReport()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        var content = "12€;3;test";
        var encoding = Encoding.UTF8;
        content = encoding.GetString(new byte[] { 0xEF, 0xBB, 0xBF }) + content;    
    
        response.Content = new StringContent(content, encoding , "text/csv");
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        {
            FileName = yourfile.csv"
        };
    
        return response;
    }
