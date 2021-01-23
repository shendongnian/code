        [HttpGet]
        public IHttpActionResult Test()
        {
            var stream = new MemoryStream();
            // ...
            // stream.Write(...);
            // ...
            stream.Position = 0;
            var content = new StreamContent(stream);
            return Ok(content);            
        }
