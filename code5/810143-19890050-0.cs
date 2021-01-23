    public HttpResponseMessage GetContacts()
    {
      var result = db.Contacts().ToList();
      return this.Request.CreateResponse(HttpStatusCode.BadRequest, result);
    }
