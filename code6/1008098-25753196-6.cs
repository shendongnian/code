    public HttpResponseMessage GetDict()
        {
        var dict=new Dictionary<string,string>();
        dict.Add("one", "a");
        dict.Add("two", "2");
        return Request.CreateResponse(HttpStatusCode.Ok, dict);
        }
