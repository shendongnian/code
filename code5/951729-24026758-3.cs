    When(HasMaterialPublishedElseWhereText, () => {
        RuleFor(x => x.DtPublishedTimeText)
            .NotEmpty()
                .WithMessage("Required Field");
        RuleFor(x => x.DtPublishedTimeText)
            .Must(BeAValidDate)
                .WithMessage("Must be date");
    });
