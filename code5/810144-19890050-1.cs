    public HttpResponseMessage GetContacts()
    {
      var result = await db.Contacts().ToListAsync();
      return this.Request.CreateResponse(HttpStatusCode.BadRequest, result);
    }
