    public IHttpActionResult Get()
    {
     ...
      return Content(HttpStatusCode.OK, Model, Configuration.Formatters.XmlFormatter);
    }
