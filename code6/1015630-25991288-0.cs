    [HttpGet]
    public ActionResult ReadFile(string path)
    {
                     
        return new FileContentResult(System.IO.File.ReadAllBytes(Server.MapPath(path)), "image");
    }
