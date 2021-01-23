     public ActionResult RenderGateway(string service)
     {
        var jsSettings = new JsonSerializerSettings();
        jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        var deserializedModel = JsonConvert.DeserializeObject<Service >(service, jsSettings);
        //now deserializedModel is of type Service 
        return PartialView("~/Views/Shared/something.cshtml", deserializedModel);
     }
