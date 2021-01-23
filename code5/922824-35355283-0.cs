    [HttpPost]
    public ActionResult SaveOrg(MyModel model)
    {
        var serializer = new JavaScriptSerializer();
        var stream = System.Web.HttpContext.Current.Request.InputStream;
        var reader = new StreamReader(stream);
        stream.Position = 0;
        var json = reader.ReadToEnd();
        model= serializer.Deserialize<MyModel>(json);
        //model.MyEmpls is [] here
    }
