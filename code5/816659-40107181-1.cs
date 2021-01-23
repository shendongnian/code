    [ActionName("DefaultApi")]
    [Route("Api/UserLogin/DefaultApi/UserDetails")] 
    public IHttpActionResult UserDetails(){
      return Ok(db.UserLogins.ToList());
    }
