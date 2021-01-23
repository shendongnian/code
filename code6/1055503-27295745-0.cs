    [Route("api/upload/")]
    [HttpPost]
    public async Task<IHttpActionResult> Upload()
    {
       if (!Request.Content.IsMimeMultipartContent())
       {
           return StatusCode(HttpStatusCode.UnsupportedMediaType);
       }
    
       var provider = new MultipartMemoryStreamProvider();
       await Request.Content.ReadAsMultipartAsync(provider);
    
       var file = provider.Contents.FirstOrDefault();
    
       if (file == null)
       {
           return BadRequest("No file found");
       }
    
       var fileStream = await file.ReadAsStreamAsync();
    
       // Do something with thte filestream
    
       return Ok();
    }
    
    [Route("api/download/{id}")]
    [HttpGet]
    public async Task<IHttpActionResult> Download(Guid id)
    {
       if (id == default(Guid))
       {
           return NotFound();
       }
    
       var file = await SomeAsynchMethod(id); // returns custom File type.
    
       if (file == null)
       {
           return NotFound();
       }
    
       var result = new HttpResponseMessage(HttpStatusCode.OK)
       {
           Content = new ByteArrayContent(file.FileDataBytes)
       };
       result.Content.Headers.ContentType = new MediaTypeHeaderValue(file.FileType);
       result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attatchment")
       {
           FileName = file.FileName
       };
    
       return ResponseMessage(result);
    }
