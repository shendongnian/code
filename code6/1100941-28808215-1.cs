    [HttpPost]
    public ActionResult Tflow(string json)
    {
        // read raw json string
        Request.InputStream.Seek(0, SeekOrigin.Begin);
        json = new StreamReader(Request.InputStream).ReadToEnd();
    
        // deserialize
        var data = JsonConvert.DeserializeObject<JsonFileContentInputs>(json);
    
        // more code
    }
