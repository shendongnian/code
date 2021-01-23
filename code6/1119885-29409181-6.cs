    [HttpPost]
    public ActionResult GetServiceData(JsonData model)
    {
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        return View(obj.GetRuleDetail(model.Id));//Tihs will simply return view
    }   
