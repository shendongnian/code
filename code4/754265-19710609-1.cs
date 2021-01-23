    [HttpPost("csv")]
    public HttpResponseMessage GetCvsReport()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
    
        var content = "12€;3;test";
        var encoding = Encoding.GetEncoding("Windows-1252");
        
        response.Content = new StringContent(content, encoding , "text/csv");
        ...
    }
