    [HttpPost]
    public async Task<object> UploadedFile()
    {
        var file = await Request.Content.ReadAsByteArrayAsync();
        Request.Headers.GetValues("fileName").FirstOrDefault();
        var fileName = Path.GetFileName(headerFileName)?.Replace(" ", "_") ?? "filename";
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
