    RuleFor(x => x.DtPublishedTimeText)
        .NotEmpty()
            .When(HasMaterialPublishedElseWhereText)
            .WithMessage("Required Field")
        .Must(BeAValidDate)
            .When(HasMaterialPublishedElseWhereText)
            .WithMessage("Must be date");
