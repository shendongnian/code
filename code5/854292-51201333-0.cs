    RuleFor(p => p).Cascade(CascadeMode.StopOnFirstFailure)
                .Must(p => !string.IsNullOrWhiteSpace(p.FirstName))
                .When(p => p.Id == 0 && string.IsNullOrWhiteSpace(p.LastName)).WithMessage("At least one is required (Id, FirstName, LastName).")
                .Must(p => !string.IsNullOrWhiteSpace(p.LastName))
                .When(p => p.Id == 0 && string.IsNullOrWhiteSpace(p.FirstName)).WithMessage("At least one is required (Id, FirstName, LastName).")
                .Must(p => p.Id != 0)
                .When(p => string.IsNullOrWhiteSpace(p.FirstName) && string.IsNullOrWhiteSpace(p.LastName)).WithMessage("At least one is required (Id, FirstName, LastName).");
