    public class RegisterViewModelValidator: AbstractValidator<RegisterViewModel>  
    {
        public RegisterViewModelValidator()
        {
            RuleFor(m => m.Password).NotEqual(m => m.UserName).WithMessage("Password Cannot Match Username");
        }
    }
