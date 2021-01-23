    [HttpPost]
    public ResponseMessageResult Post(Thing thing)
    {
        var content = "\r";
        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Accepted) {
          RequestMessage = Request,
          Content = new StringContent(content)
        };
        return ResponseMessage(httpResponseMessage);
    }
