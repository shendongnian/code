    public ActionResult GetFile(string filename)
    {
        string actualFile = Path.Combine("D:\Uploaded-Files", filename);
        return File(actualFile, "application/octet-stream");
    }
