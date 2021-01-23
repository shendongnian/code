    public JsonResult GetProperties()
    {
      UserModel old = //
      UserModel new = //
      List<PropertiesVM> model = new List<PropertiesVM>();
      foreach (PropertyInfo propertyInfo in typeof(UserModel).GetProperties())
      {
        PropertiesVM prop = new PropertiesVM();
        prop.Name = propertyInfo.Name;
        prop.OldValue = propertyInfo.GetValue(model, null);
        prop.NewValue = propertyInfo.GetValue(m, null);
        propertyNameList.Add(prop);
      }
      return Json(model, JsonRequestBehavior.AllowGet);
    }
