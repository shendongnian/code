    public ActionResult Index(string xml)
    {
        // parse xml into some custom model class
        XmlParserModel model = ParseXml(xml);
        return View(model);
    }
