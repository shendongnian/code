      <TextBox>
            <TextBox.Text>
                <Binding Path="Name" ValidatesOnDataErrors="True" UpdateSourceTrigger="PropertyChanged">
                    <Binding.ValidationRules>
                        <local:Validation2/>
                    </Binding.ValidationRules>
                </Binding>
            </TextBox.Text>
        </TextBox>
    public class Validation2 : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double result;
            return double.TryParse(value.ToString(), out result) == true ? new ValidationResult(true, null) : new ValidationResult(false, "error");
        }
    }
