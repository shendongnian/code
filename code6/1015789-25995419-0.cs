    [HttpPost]
    public JsonResult RegisterAndLogin(UserRegisterViewModel model)
    {
      bool successToStoreData = SomeMethod(model);
      if (successToStoreData)
      {
        return null; // indicates success
      }
      else
      {
        return Json("Your error message");
      }
    }
