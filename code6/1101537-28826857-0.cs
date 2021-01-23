	public class MyValidationAttribute: ValidationAttribute
	{
		public MyValidationAttribute(int monthsSpan)
		{
			this.MonthsSpan = monthsSpan;
		}
		public int MonthsSpan { get; private set; }
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				var date = (DateTime)value;
				var now = DateTime.Now;
				var futureDate = now.AddMonths(this.MonthsSpan);
				if (now <= date && date < futureDate)
				{
					return null;
				}
			}
			return new ValidationResult(this.FormatErrorMessage(this.ErrorMessage));
		}
	}
