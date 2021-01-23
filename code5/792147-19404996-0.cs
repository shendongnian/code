    public ActionResult DownloadConfigurationFiles()
    {
        var bytes = this.HttpContext.GetSessionObj<byte[]>(idx_here);
    
        if bytes != null) // check existance
        {
             var target = new MemoryStream(bytes); // <-- don't use USING!
    
             this.HttpContext.ClearSessionObj(idx_here);
    
    	     return File(target, mime, file_name);
        }
    
        return HttpNotFound();
    }
