    public ActionResult Update()
    {
        var inputStream = Request.InputStream;
        inputStream.Seek(0, SeekOrigin.Begin);
        var request = new StreamReader(inputStream).ReadToEnd();
        var soapRequest = XDocument.Parse(request);
        ...
    }
