    public ActionResult Details(string id)
    {
         using (var context = contextFactory.Create())
         {
              var profile = context.UserProfiles.FirstOrDefault(x => x.Id == id);
    
              return View(profile);         
         }   
    }
