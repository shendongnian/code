    public class DepartmentValidationRule : System.Windows.Controls.ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo ultureInfo)
        {
            if (String.IsNullOrWhiteSpace(value as string))
            {
                return new System.Windows.Controls.ValidationResult(false, "The value is not a valid");
            }
            else
            {
                return new System.Windows.Controls.ValidationResult(true, null);
            }
        }
    }
