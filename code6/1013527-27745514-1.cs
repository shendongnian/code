    public class RegistrationController
        [HttpPost]
        public ActionResult Join(UserJoinViewModel user)
        {
             ...
        }
    }
    [MetadataType(typeof(UserJoinViewModel_Validation))]
    public partial class UserJoinViewModel : User
    {
        // properties unique to the view model
    }
    public class UserJoinViewModel_Validation
    {
         [Required]
         [EmailAddress]
         public Email { get; set; }
    }
