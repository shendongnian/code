    public ViewResult Index()
    {
        return View();
    }
    [HttpPost]
    public ViewResult ShowFile(string imageId)
    {
        var virtualPath = string.Format("~/images/profile/{0}.jpg", imageId);
        if (System.IO.File.Exists(Server.MapPath(virtualPath)))
        {
            ViewBag.Foto = VirtualPathUtility.ToAbsolute(virtualPath);
        }
        return View("Index");
    }
