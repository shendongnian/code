    [HttpGet]
    public ContentResult Index() 
    {
        return new ContentResult 
        {
            ContentType = "text/html",
            Content = "<div>Hello World</div>"
        };
    }
