    public class RegistrationController
        [HttpPost]
        public ActionResult Join(UserJoinViewModel user)
        {
             ...
        }
    }
    public class UserJoinViewModel : UserBaseViewModel
    {
         [Required]
         [EmailAddress]
         public Email { get; set; }
    }
