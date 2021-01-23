    public sealed class ValidFiscalYearAttribute : ValidationAttribute, IClientValidatable 
    {
        private int currentFiscalYear;
        public ValidFiscalYearAttribute() : base("Fiscal Year must be between {0} and {1}.")
        { 
            var currentFiscalYearString = HttpContext.Current.Request[FiscalYear];
            currentFiscalYear = int.Parse(currentFiscalYearString);
        }
        public string FiscalYear { get; set; }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, currentFiscalYear, currentFiscalYear + 10);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You should not check for null as checking for null should be the responsibility of the Required attribute
            var fiscalYear = (int)value;
            var valid = fiscalYear >= currentFiscalYear && fiscalYear <= currentFiscalYear + 10;
            if (!valid)
            {
                var message = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(message);
            }
            return null;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "fiscalyear";
            rule.ValidationParameters.Add("currentfiscalyear", currentFiscalYear);
            yield return rule;
        }
    }
