    public IHttpActionResult Error()
    {
        var error = new HttpError();
        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
    }
