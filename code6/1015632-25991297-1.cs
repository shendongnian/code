    public ActionResult ReadFile(string path)
    {
        byte[] imgBytes = System.IO.File.ReadAllBytes(path);
        return File(imgBytes, "image/png"); 
    }
