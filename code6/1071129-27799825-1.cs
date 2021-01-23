    public class InstitutionValidator : AbstractValidator<Institution>
    {
        public InstitutionValidator()
        {
            RuleFor(institution => institution.Name).NotNull().Length(1, 100).WithLocalizedName(() => Prim.Mgp.Infrastructure.Resources.GlobalResources.InstitutionName);       
            RuleFor(institution => institution.OrganizationId).GreaterThan(0);
            RuleFor(institution => institution.ReplicationKey).NotNull().NotEqual(Guid.Empty);
        }  
    }
