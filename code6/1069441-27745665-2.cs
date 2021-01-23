    public sealed class FiscalYearAttribute : ValidationAttribute
    {
        public string CurrentFiscalYear { get; set; }
        public override bool IsValid(object value)
        {
            var currentFiscalYearString = HttpContext.Current.Request[CurrentFiscalYear];
            var currentFiscalYear = int.Parse(currentFiscalYearString);
            var fiscalYear = (int) value;
            return fiscalYear >=  currentFiscalYear && fiscalYear <= currentFiscalYear + 10;
        }
        public override string FormatErrorMessage(string name)
        {
            return name + " error description here.";
        }
    }
