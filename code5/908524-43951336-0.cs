    public IHttpActionResult Get()
    {
        var result = Request.CreateResponse(HttpStatusCode.OK, 
                                            model,
                                            Configuration.Formatters.XmlFormatter);
         
        result.Headers.Add("Access-Control-Allow-Origin", "*");
        return ResponseMessage(result);
    }
