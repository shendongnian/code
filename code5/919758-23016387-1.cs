    public IHttpActionResult Get()
    {
         Object obj = new Object();
         if (obj == null)
             return NotFound();
         return Ok(obj);
     }
