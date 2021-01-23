    [HttpPost]
    public async Task<object> UploadMethod()
    {
        var file = await Request.Content.ReadAsByteArrayAsync();
        var fileName = Request.Headers.GetValues("fileName").FirstOrDefault();
        var filePath = "/upload/files/";
        try
        {
            File.WriteAllBytes(HttpContext.Current.Server.MapPath(filePath) + fileName, file);           
        }
        catch (Exception ex)
        {
            // ignored
        }
    
        return null;
    }
