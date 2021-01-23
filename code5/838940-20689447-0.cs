    [Route("")]
        [HttpGet]
        public ActionResult GetFeeds(Location location = null)
        {
            if (location == null)
            {
                // init location or smth
            }
    
            // Do smth with location
    
            return new EmptyResult();
       }
