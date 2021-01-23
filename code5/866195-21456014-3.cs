    public ActionResult SaveComplete(RegistrationViewModel model)
    {
     model.BasicInfo=JsonConvert.DeserializeObject<BasicInfo>(model.JsonBasicInfo);
     //save whole data
    }
