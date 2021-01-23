    public class ValidateUpdateOfficeCommand : AbstractValidator<UpdateOffice>
    {
        public ValidateUpdateOfficeCommand(DbContext dbContext)
        {
            RuleFor(x => x.OfficeId)
                .MustFindOfficeById(dbContext);
    
            RuleFor(x => x.RegionId)
                .MustFindRegionById(dbContext);
    
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 200)
                .MustBeUniqueOfficeName(dbContext, x => x.OfficeId);
        }
    }
