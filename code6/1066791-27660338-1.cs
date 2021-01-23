    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        private readonly IRepository _repository;
    
        public RegisterModelValidator(IRepository repository)
        {
            this._repository= repository;
    
            RuleFor(x => x.AgencyId).GreaterThan(0).WithMessage("Invalid AgencyId");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Invalid Age");
            Custom(c =>
                    {
                        var requirements = _repository.GetRequirementsForAgency(model.AgencyId);
                        \\validate each property according to requirements object.
                        \\if (Validation fails for some property)
                            return new ValidationFailure("property", "message");
                        \\else
                        return null;
                    });
        }
    }
