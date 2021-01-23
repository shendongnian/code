    public ActionResult GetImage()
    {
        byte[] byteArray = MagicMethodToGetImageData();
        var results = new 
        {
            Image = Convert.ToBase64String(byteArray),
            OtherData = "some data"
        };
        
        return Json(results);
    }
