    [HttpPut]
    public IHttpActionResult Approve(long id)
    {
        if (!ModelState.IsValid)
        {   
            return BadRequest();
        }
        // .....
        // .....
        
        bool success = false;// this is just a flag to indicate operation progress   
        
        // Do Update... 
        return Ok(sucess);
    }
