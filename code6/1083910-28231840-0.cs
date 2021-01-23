    public ActionResult Contact()
    {
        ViewBag.Message = "Your file page.";
        DirectoryInfo dirInfo = new DirectoryInfo(@"c:\");
        List<FileInfo> files = dirInfo.GetFiles().ToList();
   
        //pass the data trough the "View" method
        return View(files);
    }
