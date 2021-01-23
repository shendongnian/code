    public IHttpActionResult SomeAction()
    {
       IHttpActionResult response;
       //we want a 303 with the ability to set location
       HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
       responseMsg.Headers.Location = new Uri("http://customLocation.blah");
       response = ResponseMessage(responseMsg);
       return response;
    }
