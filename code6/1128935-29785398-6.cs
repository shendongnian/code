    [HttpGet]
    		public ActionResult Create()
    		{
    			return View(new ProfileMeta());
    		}
         [HttpPost]
    
         [ValidateAntiForgeryToken]
             public ActionResult Create(Register register)
                {
                    if (ModelState.IsValid)
                     {            
                        db.ProfileMetas.Add(profileMeta);
                        db.ProfileDetails.Add(profileDetail);
                        db.SaveChanges();
                     }
               }
