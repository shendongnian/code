    [HttpGet]
    public HttpResponseMessage Get(int id)
    {
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        FileInfo fileInfo = logic.GetFileInfoSync(id);
    
        FileStream fs = new FileStream(
            filePath, FileMode.Open, FileAccess.Read, FileShare.None, BufferSize, false);
    
        result.Content = new StreamContent(fs);
        result.Content.Headers.ContentType = 
            new MediaTypeHeaderValue("application/octet-stream");
        result.Content.Headers.ContentDisposition = 
            new ContentDispositionHeaderValue("attachment") 
            {
                FileName = fileInfo.Node.Name + fileInfo.Ext
            };
        result.Content.Headers.ContentLength = fileInfo.SizeInBytes;
        return result;
    }
