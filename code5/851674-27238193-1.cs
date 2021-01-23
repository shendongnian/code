    [HttpPost]
    [Route("")]
    public HttpResponseMessage Post()
    {
        var values = HttpContext.Current.Server.UrlDecode(Request.Content.ReadAsStringAsync().Result).Replace("val=","").Split(',');
    ...
    }
