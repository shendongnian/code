    public ActionResult Catch()
    {
        var reader = new StreamReader(Request.InputStream);
        var rawString = reader.ReadToEnd();
        //do something here.
    }
