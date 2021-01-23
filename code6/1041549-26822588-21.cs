    [HttpGet]
    public ContentResult Index() {
        return new ContentResult {
            ContentType = "text/html",
            StatusCode = (int)HttpStatusCode.OK,
            Content = "<html><body>Hello World</body></html>"
        };
    }
