    public ActionResult NIRInfo()
    {
        List<string> filesList = new List<string>();
        
        string fileDownloadPath =   System.Configuration.ConfigurationManager.AppSettings["DownloadDocumentsPath"];
    
        var dir = new System.IO.DirectoryInfo(@fileDownloadPath );
        System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
        var xow = from i in db.NIRs where i.Id == id select i.File;
        foreach (var i in xow)
        {
            fileNames = dir.GetFiles(i);
            foreach (var f in fileNames)
            {
                filesList.Add(f.Name);
            }
            ViewData["fList"] = filesList;
        }
        return View(nir);
    }
