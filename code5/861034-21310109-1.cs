    public class GuitarValidator : AbstractValidator<Guitar>
    {
        public GuitarValidator()
        {
            // All your other validation rules for Guitar. eg.
            RuleFor(x => x.Make).NotNull();
        }
     }
