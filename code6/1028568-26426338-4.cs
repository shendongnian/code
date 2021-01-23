    public class VinValidator : AbstractValidator<Vin>
    {
        public VinValidator()
        {
            RuleFor(x => x.Vin)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(HaveValidMake).WithMessage("Invalid Make")
                .Must(HaveValidModel).WithMessage("Invalid Model")
                .Must(HaveValidYear).WithMessage("Invalid Year")
                .Must(BeValidVin).WithMessage("Invalid VIN");
        }
    
        private bool HaveValidMake(string vin)
        {
            return vin.Contains("make");
        }
    
        private bool HaveValidModel(string vin)
        {
            return vin.Contains("model");
        }
    
        private bool HaveValidYear(string vin)
        {
            return vin.Contains("year");
        }
    
        private bool BeValidVin(string vin)
        {
            return vin.Length == 17;
        }
    }
