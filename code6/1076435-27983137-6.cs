    public async Task<IHttpActionResult> UploadFile()
    {
        if (!Request.Content.IsMimeMultipartContent())
        {
            return StatusCode(HttpStatusCode.UnsupportedMediaType);
        }        
      
        var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
        
        foreach (var stream in filesReadToProvider.Contents)
        {
            var fileBytes = await stream.ReadAsByteArrayAsync();
        }
    }
