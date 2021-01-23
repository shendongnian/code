    [HttpPut]
    [ActionName("Put")]
    public void Put(long id, ExampleModel model) {
        if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
        // Do something with the model
    }
