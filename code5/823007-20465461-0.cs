    public class ParentClassValidator : AbstractValidator<ParentClass>
    {
        public ParentClassValidator(bool childIsNotNull)
        {
            RuleFor(x => x.Child).NotNull();
       
        if (childIsNotNull) {
            RuleFor(x => x.Date).Must((parent, date) => 
                date < parent.Child.EndDate && date > parent.Child.StartDate);
            // ...other rules.
        }
    }
