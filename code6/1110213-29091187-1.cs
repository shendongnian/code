    [AcceptVerbs(HttpVerbs.Post)]
    public string GetFile(string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            // Do some stuff with string array here.
        }
        Guid token = Guid.NewGuid();
        InMemoryInstances instance = InMemoryInstances.Instance;
        instance.addToken(token.ToString());
        HttpCookie cookie = new HttpCookie("CookieToken");
        cookie.Value = token.ToString();
        this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
        return token.ToString();
    }
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult GetFile()
    {
        string filename = @"c:\temp\afile.txt";
        InMemoryInstances instance = InMemoryInstances.Instance;
            
        if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieToken"))
        {
            HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["CookieToken"];
                
            if (instance.checkToken(cookie.Value)) 
            {                                
                cookie.Expires = DateTime.Now.AddDays(-1);            
                  this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                FileStreamResult resultStream = new FileStreamResult(new FileStream(filename, FileMode.Open, FileAccess.Read), "txt/plain");
                resultStream.FileDownloadName = Path.GetFileName(filename);
                return resultStream;
            } else 
            {
                return View("Index");
            }
        }            
        else
        {
            return View("Index");
        }
            
    }
