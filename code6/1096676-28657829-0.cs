     [HttpPost]
      [AllowAnonymous]
      [ValidateAntiForgeryToken]
    public ActionResult GetCultureResource()
    {
          ResourceSet resourceSet = 
      Resources.Resources.ResourceManager.GetResourceSet(new  System.Globalization.CultureInfo(cultureName), true, true);
       var dicResource= resourceSet.Cast<DictionaryEntry>()
                      .ToDictionary(x => x.Key.ToString(),
                                    x => x.Value.ToString());
            
       var jsonString = JsonConvert.SerializeObject(dicResource);
                       
      return Json(new { resource = jsonString});
            
     }
