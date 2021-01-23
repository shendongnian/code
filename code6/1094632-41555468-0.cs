    public IHttpActionResult Get()
    {
       HttpResponseMessage responseMessage = ...
       return new ResponseMessageResult(responseMessage);
    }
