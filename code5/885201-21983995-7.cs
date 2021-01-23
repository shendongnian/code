    public class NameLengthRule : ValidationRule
    {
    	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    	{
    		string name = value as string;
    		return string.IsNullOrWhiteSpace(name) ? new ValidationResult(false, "Name can't be empty") : new ValidationResult(true, null);
    	}
    }
