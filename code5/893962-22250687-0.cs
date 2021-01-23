    [Validator(typeof(ApplicationUserValidator))]
    class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        //...Model implementation omitted
    }
    
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
    
            RuleFor(x => x.Email).Must(IsUniqueEmail).WithMessage("Email already exists");
        }
        private bool IsUniqueEmail(string mail)
        {
            var _db = new DataContext();
            if (_db.NewModel.SingleOrDefault(x => x.Email == mail) == null) return true;
            return false;
        }
        //implementing additional validation for other properties:
        private bool IsUniqueTelephoneNumber(string number)
        {
          //...implement here
        }
    }
