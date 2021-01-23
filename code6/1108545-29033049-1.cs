    [AttributeUsage(AttributeTargets.Property)]
	public class FutureDateValidation : ValidationAttribute {
		protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			DateTime inputDate = (DateTime)value;
			if (inputDate > DateTime.Now) {
				return ValidationResult.Success;
			} else {
				return new ValidationResult("Please, provide a date greather than today.", new string[] { validationContext.MemberName });
			}
		}
	}
	public class Group {
		[FutureDateValidation()]
        [DataType(DataType.Date, ErrorMessage = "Please provide a valid date.")]
		public DateTime GroupDateTime { get; set; }
	}
