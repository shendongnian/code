    [HttpPost]
    public ActionResult filexist()
    {
     string subPath = "~/Content/74/74/6_Hall0/Text/data.txt";
     bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));
     if (!exists)
       System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
     else
       {
       }
     return View();
    }
