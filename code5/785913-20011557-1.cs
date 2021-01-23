      public class ProspectValidator: AbstractValidator<Prospect>
        {
            public CurrentUserValidator()
            {
                RuleFor(p => p.CompetitorProducts)
                  .Cascade(CascadeMode.StopOnFirstFailure)
                  .NotNull()
                  .SetValidator(new CompetitorProductsValidator())
                  .When(p => !p.ExistingCustomer);
            }
        }
    
        public class CompetitorProductsValidator : AbstractValidator<Prospect.CompetitorProducts>
        {
            public CompetitorProductsValidator()
            {
                RuleFor(p => p.Count)
                  .GreaterThan(0);
            }
        }
