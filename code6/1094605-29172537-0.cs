    // remove the if() statement, and use .When()
    RuleFor(x => x.TempCardNumber)
        .NotEmpty().WithLocalizedMessage(ResourceAreas.Messages.Message_AccountSetup_100006_tempcard)
        .Matches(regexPatterns.NumericOnly)
        .WithLocalizedMessage(ResourceAreas.Messages.Message_Onboarding_100007_numbersonly)
        .Length(15).WithLocalizedMessage(ResourceAreas.Messages.Message_AccountSetup_100006_tempcard)
        .When(x => x.HasProvisionalAccount);
    
    RuleFor(x => x.SecurityCode)
        .NotEmpty().WithLocalizedMessage(ResourceAreas.Messages.Message_AccountSetup_100006_tempcard)
        .Matches(regexPatterns.NumericOnly)
        .WithLocalizedMessage(ResourceAreas.Messages.Message_Onboarding_100007_numbersonly)
        .Length(4).WithLocalizedMessage(ResourceAreas.Messages.Message_AccountSetup_100006_securitycode)
        .When(x => x.HasProvisionalAccount);
