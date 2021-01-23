    [HttpGet]
    [ActionName("Edit")]
    public ActionResult UpdateDevice(string code)
    {
        Session["code"] = code;
        ....
    }
    [HttpPost]
    [ActionName("Edit")]
    public ActionResult UpdateDevice(DeviceModel model)
    {
        if (Session["code"] == null)
           throw new Exception("Error Message.");
        var code = Session["code"];
        ....
        Session["code"] = null;
    }      
