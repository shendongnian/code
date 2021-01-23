    public HttpResponseMessage Post()
    {
        return Request.CreateResponse(HttpStatusCode.OK, new
        {
            openTimes = new output() { prop1 = "09:00", prop2 = "09:15", prop3 = "09:30" }
        });
    }
