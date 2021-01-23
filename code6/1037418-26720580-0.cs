    public ActionResult GetSwf(long id = 0)
    {
        if (id <= 0) return null;
        Attachment attachment = Service.GetAttachmentById(id);
        if (attachment == null) return null;
    
        string filename = attachment.Name;
        string mimeType = "application/x-shockwave-flash";
        string absoluteFilePath = UploadedPaths.GetAbsolutePath(attachment.Path);
    
        byte[] bytes = System.IO.File.ReadAllBytes(absoluteFilePath);
        return new FileContentResult(bytes, mimeType);
    }
