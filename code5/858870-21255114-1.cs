    private void UploadWholeFile(HttpContext context, List<FilesStatus> statuses)
    {
        string path = HttpContext.Current.Server.MapPath("~/App_data/UploadedFiles/");
        for (int i = 0; i < context.Request.Files.Count; i++)
        {
            var file = context.Request.Files[i];
            file.SaveAs(path + file.FileName);
            ...
        }
    }
