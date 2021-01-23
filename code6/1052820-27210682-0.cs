      [Route("Encrypt/{clientSecret}")]
      [HttpPost]
      public IHttpActionResult Encrypt(string clientSecret) {
                ...
                return Ok();
           }
  
