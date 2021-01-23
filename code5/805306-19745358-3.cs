    public class RegisterViewModel {
         [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
         public string fname { get; set; }
          [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
         public string lname { get; set; }
     }
