    [HttpPost]
    public ActionResult AddUser(AddUserModel model)
    {
         if(ModelState.IsValid)
         {
             // input parameters passed - now check for uniqueness in db
              using(var db = new DbContext())
              {
                   if(!db.User.Any(x => x.Name.Equals(model.Name, StringComparison.IgnoreOrdinalCase)))
                   {
                         // Add to database
                         return;
                   }
                   else
                   {
                        // hard code string or get model property name via reflection etc
                        // Or if you want a general error you can use string.Empty as the key name and display via the validation summary
                        ModelState.AddModelError("Name", "Name must be unique");
                        
                        // Fall through and return error 
                   }                
         }
         return View(model);
    }
