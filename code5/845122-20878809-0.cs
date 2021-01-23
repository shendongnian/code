    [HttpPost]       
    public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
    {
        // reject if no file is send
        if(files == null || !files.Any())
        {
            // return error or throw exception
        }
        // create folder if not exist
        if(!Directory.Exists(Server.MapPath("~/TempImages/")))
        {
            // create folder
        }
        // base path for images
        string TempPath = Server.MapPath("~/TempImages/");
        // list to save file paths
        List<string> myTempPaths = new List<string>();
        foreach (HttpPostedFileBase file in files)
        {
            string filePath = Path.Combine(TempPath, file.FileName);
            
            // save file
            file.SaveAs(filePath);
            
            // add path to list
            myTempPaths.Add(filePath);
        }
        // save paths into temp Data
        TempData["lev1"] = myTempPaths;
        return View();
    }
