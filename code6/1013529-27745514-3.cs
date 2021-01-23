    public class RegistrationController
        [HttpPost]
        public ActionResult Provide(UserProvideViewModel user)
        {
             ...
        }
        [HttpPost]
        public ActionResult Join(UserJoinViewModel user)
        {
             ...
        }
    }
    [MetadataType(typeof(UserProvideViewModel_Validation))]
    public partial class UserProvideViewModel : User
    {
        // properties unique to the view model
    }
    public class UserProvideViewModel_Validation
    {
        [RegularExpression(@"^([1-9]|\d{2,10})$")]
         public Id { get; set; }
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
