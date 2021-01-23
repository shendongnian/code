    // GET /api/controllername
    // GET /api/controllername/get
    [HttpGet]
    public HttpResponseMessage Get()
    {
        ...
    }
    // GET /api/controllername/get/123
    [HttpGet]
    public HttpResponseMessage Get(int id)
    {
        ...
    }
    // GET /api/controllername/GetMessagesForApp/abc
    [HttpGet]
    public HttpResponseMessage GetMessagesForApp(string id)
    {
        ...
    }
