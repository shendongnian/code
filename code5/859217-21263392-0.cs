     public class GiftViewModel
    {
       public class LoginModel
       {
            [Required(ErrorMessage = "Email Required")]
            RegularExpression(".+\\@.+\\..+", ErrorMessage = "You must type in a valid email address.")]
            public string Email { get; set; }
        
            [Required(ErrorMessage = "Password Required")]
            public string password { get; set; }
       }
    }
     public ActionResult Login(GiftViewModel model)
     {
          if(TryValidateModel(model))
          {
             ///validated with all validations
           }
        return View("Index", model);
    }
