    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
        if (this.HasMaterialPublishedElseWhereText == "Yes") {
            yield return new ValidationResult("This isn't valid! Let me tell you why...");
        }
    }
