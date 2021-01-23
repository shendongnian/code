    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Index()
    {
        string xml = "";
        if(Request.InputStream != null){
            StreamReader stream = new StreamReader(Request.InputStream);
            string x = stream.ReadToEnd();
            xml = HttpUtility.UrlDecode(x);
        }
        ...
        return View(model);
    }
