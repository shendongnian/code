    [Route("apiname/authroizedLogin")]
    [Authorize(Roles="admin")]
    public void IHttpActionResult(string username, stringpassword)
    {
       try
       {
        dosomething...
        return Ok(somecontext);
       }
       catch(exception e)
       {
        return BadResponse(e.message);
       }
    }
