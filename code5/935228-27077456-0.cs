        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            // The header can have multiple values, I call SingleOrDefault as I only expect 1 value.
            var myHeader = Request.Headers.GetValues("X-My-Header").SingleOrDefault();
            if (myHeader == "success")
            {
                 return Ok<string>("Success!");
            }
        
             return BadRequest();
        }
    
