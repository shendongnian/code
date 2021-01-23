    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.EmailAddress).NotNull();
            RuleFor(x => x.Guitars).SetCollectionValidator(new GuitarValidator());
        }
    }
