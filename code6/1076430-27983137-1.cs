    public async Task<IHttpActionResult> UploadFile()
    {
    if (!Request.Content.IsMimeMultipartContent())
             {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
             }
    
     var fileMemoryProvider = new MultipartFormDataMemoryStreamProvider();
    
    var filesReadToProvider = await Request.Content.ReadAsMultipartAsync(fileMemoryProvider);
    
     foreach (var stream in filesReadToProvider.Contents)
                {
     var fileBytes = await stream.ReadAsByteArrayAsync();
    }
    }
