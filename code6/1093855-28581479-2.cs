    public ImageValidator()
    {
        RuleFor(e => e.Name).NotEmpty().Length(1, 255).WithMessage("Name must be between 1 and 255 chars");
        RuleFor(e => e.Data).IsImage((e, bitmap) =>
        {
            e.Height = bitmap.Height;
            e.Width = bitmap.Width;
        }).WithMessage("Image data is not valid").When(e => e.Id == 0);
        RuleFor(e => e.Height).GreaterThan(0).WithMessage("Image must have a height");
        RuleFor(e => e.Width).GreaterThan(0).WithMessage("Image must have a width");
    }
