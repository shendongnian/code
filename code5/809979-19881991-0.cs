    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull();
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.User.Password);
        }
    }
