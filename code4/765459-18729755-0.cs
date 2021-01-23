    public class SoftwareOrder
    {
        public bool IsLegacySystem;
        public List<SoftwareItem> Software;
    }
    public class SoftwareItem
    {
        public bool Selected;
        public bool IsLegacySoftware;
        public int SoftwareId;
    }
    public class SoftwareOrderValidator : AbstractValidator<SoftwareOrder>
    {
        public SoftwareOrderValidator()
        {
            Custom(order =>
            {
                if (order.Software == null)
                    return null;
                return order.Software.Any(item => order.IsLegacySystem != item.IsLegacySoftware)
                   ? new ValidationFailure("Software", "Software is incompatible with system")
                   : null;
            });
            // Validations other than legacy check
            RuleFor(order => order.Software).SetCollectionValidator(new SoftwareItemValidator());
        }
    }
    public class SoftwareItemValidator : AbstractValidator<SoftwareItem>
    {
        // Validation rules other than legacy check
        public SoftwareItemValidator()
        {
        }
    }
