    public ActionResult Log()
     {
        var fileContents = System.IO.File.ReadAllText(Server.MapPath("~/Views/Builder/TestLogger.txt"));
        return Content(fileContents);
     }
