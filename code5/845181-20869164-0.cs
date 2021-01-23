    public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
    {
        List<string> paths = new List<string>();
        foreach (HttpPostedFileBase file in files)
        {
            string filePath = Path.Combine(TempPath, file.FileName);
            paths.Add (filePath);
                
        }
        Tempdata["paths"] = paths;
    }
