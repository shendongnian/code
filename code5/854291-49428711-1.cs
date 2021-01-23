    public CustomerSourceValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x)
                .NotNull().WithErrorCode("source_id_or_email_required")
                .When(source => source.Email == null && source.Id == null);
            RuleFor(x => x.Id)
                .NotNull().WithErrorCode("source_id_required")
                .Matches(CommonValidationRegex.CustomerIdRegexString).WithErrorCode("source_id_invalid")
                .When(source => source.Id != null);
            RuleFor(x => x.Email)
                .NotNull().WithErrorCode("source_email_required")
                .Matches(CommonValidationRegex.EmailRegexString).WithErrorCode("source_email_invalid")
                .When(source => source.Email != null);
        }
