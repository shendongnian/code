    [HttpPut]
    public IHttpActionResult Approve(long id)
    {
        if (!ModelState.IsValid)
        {
            Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            return NotFound();
        }
        // Do Update...
        return Ok(true);
    }
