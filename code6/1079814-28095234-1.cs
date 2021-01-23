    	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable
	{
		string otherPropertyName;
		public DateGreaterThanAttribute(string otherPropertyName, string errorMessage = null)
			: base(errorMessage)
		{
			this.otherPropertyName = otherPropertyName;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			ValidationResult validationResult = ValidationResult.Success;
			// Using reflection we can get a reference to the other date property, in this example the project start date
			var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
			// Let's check that otherProperty is of type DateTime as we expect it to be
			if (otherPropertyInfo.PropertyType.Equals(new DateTime().GetType()))
			{
				DateTime toValidate = (DateTime)value;
				DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
				// if the end date is lower than the start date, than the validationResult will be set to false and return
				// a properly formatted error message
				if (toValidate.CompareTo(referenceProperty) < 1)
				{
					validationResult = new ValidationResult(this.GetErrorMessage(validationContext));
				}
			}
			else
			{
				// do nothing. We're not checking for a valid date here
			}
			return validationResult;
		}
		public override string FormatErrorMessage(string name)
		{
			return "must be greater than " + otherPropertyName;
		}
		private string GetErrorMessage(ValidationContext validationContext)
		{
			if (!this.ErrorMessage.IsNullOrEmpty())
				return this.ErrorMessage;
			else
			{
				var thisPropName = !validationContext.DisplayName.IsNullOrEmpty() ? validationContext.DisplayName : validationContext.MemberName;
				var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
				var otherPropName = otherPropertyInfo.Name;
				// Check to see if there is a Displayname attribute and use that to build the message instead of the property name
				var displayNameAttrs = otherPropertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
				if (displayNameAttrs.Length > 0)
					otherPropName = ((DisplayNameAttribute)displayNameAttrs[0]).DisplayName;
				return "{0} must be on or after {1}".FormatWith(thisPropName, otherPropName);
			}
		}
		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			//string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
			string errorMessage = ErrorMessageString;
			// The value we set here are needed by the jQuery adapter
			ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
			dateGreaterThanRule.ErrorMessage = errorMessage;
			dateGreaterThanRule.ValidationType = "dategreaterthan"; // This is the name the jQuery adapter will use
			//"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
			dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);
			yield return dateGreaterThanRule;
		}
	}
