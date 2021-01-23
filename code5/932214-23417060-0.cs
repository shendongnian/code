    public class RoleGroupValidator : AbstractValidator<RoleGroup>
    {
        public RoleGroupValidator()
        {
            RuleFor(x => x.RoleID).NotNull().WithMessage("A");
            RuleFor(x => x.ComponentGroupID).NotNull().WithMessage("A");
            RuleFor(x => x.OperationID).NotNull().WithMessage("A");
            RuleFor(x => x).Must(x => !IsDuplicate(x));
        }
        private bool IsDuplicate(RoleGroup r)
        {
            var business = new RoleGroupBusiness();
            return business.Any(x => x.RoleID == r.RoleID &&
                                     x.ComponentGroupID == r.ComponentGroupID &&
                                     x.OperationID == r.OperationID);
        }
    }
