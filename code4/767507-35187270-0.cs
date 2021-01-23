    public class ChildValidator : AbstractValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(model => model.ChildProperty).NotEmpty();
            //Compare birthday to make sure date is < Parents birthday
        }
    }
    public class ParentValidator : AbstractValidator<Parent>
    {
        public ParentValidator()
        {
             RuleFor(model => model.Name).NotEmpty();
             RuleFor(model => model.Children)
                                 .SetCollectionValidator(x => new ChildValidator(x));
        }
    }
