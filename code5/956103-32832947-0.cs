    public class MyValidator : PropertyValidator
    {
        public MyValidator ()
            : base("Value must be null or between 0 and 3.")
        {
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }
            var value = (decimal)context.PropertyValue;
            return value >= 0m && value <= 3m;
        }
    }
