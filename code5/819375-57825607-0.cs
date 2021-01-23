    public async Task<IHttpActionResult> Get([FromUri]string id)
    {
       var item = await _service.GetItem(id);
       if(item == null)
       {
    	   StatusCode(HttpStatusCode.NotFound);
       }
       return Ok(item);
    }
