    public class ParentValidator : AbstractValidator<Parent>
    {
        public ParentValidator()
        {
             RuleFor(model => model.Name).NotEmpty();
             RuleForEach(model => model.Children)
                        .SetValidator(new ChildValidator(model));
        }
    }
    public class ChildValidator : AbstractValidator<Child>
    {
        public ChildValidator(Parent parent)
        {
            RuleFor(model => model.ChildProperty).NotEmpty();
            RuleFor(model => model.BirthDay).GreaterThan(parent.BirthDay);
        }
    }
