    public class CustomRegistrationValidator : RegistrationValidator
    {
        public CustomRegistrationValidator()
        {
            RuleSet(ApplyTo.Post, () =>
            {
                RuleFor(x => x.UserName).Must(x => false)
                    .WithMessage("CustomRegistrationValidator is fired");
            });
        }
    }
