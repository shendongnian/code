        [HttpGet]
        public IHttpActionResult Generate2()
        {
            var stream = new MemoryStream();
            ... processing stream
            var content = new ByteArrayContent(stream.GetBuffer());
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            content.Headers.ContentDisposition.FileName = "CertificationCard.pdf";
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return Ok(content);
        }
