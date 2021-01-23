    public ActionResult ViewProfile(string userToView)
    {
           var model = new MyModel();
       
           //all the logic to fill the model
           if(CurrentUser.IsLoggedIn)
           {
                return View("ViewProfile", model);
           }
           else
           {
                return View("ViewProfileNotLoggedIn", model);
           }
    }
