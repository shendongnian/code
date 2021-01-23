    public ActionResult MyAction()
    {
        string base64String = // get from Linux system
        byte[] zipBytes = Convert.FromBase64String(base64String);
        return File(zipBytes, "application/zip");
    }
