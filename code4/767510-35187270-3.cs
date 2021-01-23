    public class ChildValidator : AbstractValidator<Child>
    {
        public ChildValidator(Parent parent)
        {
            RuleFor(model => model.ChildProperty).NotEmpty();
            RuleFor(model => model.Birthday).Must(birthday => parent.Birthday > birthday);
            
        }
    }
    public class ParentValidator : AbstractValidator<Parent>
    {
        public ParentValidator()
        {
             RuleFor(model => model.Name).NotEmpty();
        }
        public override ValidationResult Validate(Parent parent)
        {
            RuleFor(model => model.Children).SetCollectionValidator(new ChildValidator(this));
        }
    }
