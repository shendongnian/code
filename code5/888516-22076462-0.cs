    public ActionResult Login(LoginModel model){
       if (!(ModelState.IsValid) || !(Membership.ValidateUser(model.username, model.password))){
         // handle error
       }
    
       .. set session variables, cookies ,etc ..
       if (User.IsInRole("Admin")){
          return Redirect(Url.Action("Index","Admin"))
       }
       if (User.IsInRole("Student")){
          return Redirect(Url.Action("Index","Student"))
       }
       ... and so on ...
    }
