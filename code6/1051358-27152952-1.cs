    public object Post(Upload request)
    {
        foreach (var uploadedFile in Request.Files
           .Where(uploadedFile => uploadedFile.ContentLength > 0))
        {
            using (var ms = new MemoryStream())
            {
                uploadedFile.WriteTo(ms);
                WriteImage(ms);
            }
        }
        return HttpResult.Redirect("/");
    }
