    [HttpGet]
        public HttpResponseMessage Get([FromUri] GeoPoint location) { ... }
    [HttpGet]
    public HttpResponseMessage Get() { 
        throw new Exception("404'd");
        ...
     }
