    [HttpPost]
    public JsonResult CreateFromFile()
    {
        byte[] data = new byte[Request.InputStream.Length];
        Request.InputStream.Read(data, 0, data.Length);
        string csv = Encoding.UTF8.GetString(data);
        // ... do something with the csv
        return Json("Sukces");
    }
