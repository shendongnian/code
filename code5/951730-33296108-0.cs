	RuleFor(x => x.DtPublishedTimeText)
		.NotEmpty()
			.WithMessage("Required Field")
		.Must(BeAValidDate)
			.WithMessage("Must be date")
		.When(HasMaterialPublishedElseWhereText);
