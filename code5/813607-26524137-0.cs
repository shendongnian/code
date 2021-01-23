    public HttpResponseMessage Get(int id)
    {
        string content = "value";
        if (id == 1)
        {
            return Request.CreateResponse<string>(HttpStatusCode.OK, content, Configuration.Formatters.JsonFormatter);
        }
        return Request.CreateResponse<string>(HttpStatusCode.OK, content, Configuration.Formatters.XmlFormatter);
    }
