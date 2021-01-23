    public Constructor(){
        // Simple validation
        RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure).NotNull().WithMessage("Must not be null");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Must not be empty");
        // advanced validation
        // item must exist in database
        RuleFor(x => x.Id).Must(ExistsInDatabase).WithMessage("Must exist in database");
        // item must exist in database previously
        // item must be some of the allowed names -- fetched from db
        RuleFor(x => x.Id).Must(BeAReferenceInSomeTable).WithMessage("Must not be referenced");
        private bool ExistsInDatabase(){}
        private bool BeAReferenceInSomeTable(){}
