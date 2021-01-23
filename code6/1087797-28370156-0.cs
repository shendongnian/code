    [HttpPost]
    public string UploadFile()
    {
        var file = HttpContext.Current.Request.Files.Count > 0 ?
            HttpContext.Current.Request.Files[0] : null;
        if (file != null && file.ContentLength > 0)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(
                HttpContext.Current.Server.MapPath("~/uploads"),
                fileName
            );
            file.SaveAs(path);
        }
        return file != null ? "/uploads/" + file.FileName : null;
    }
