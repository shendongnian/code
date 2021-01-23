    public class MyValidator: PropertyValidator 
    {
        public MyValidator(
            string errorMessage = "default Message") : base(errorMessage)
        {
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as String;
            return IsValid(stringToValidate);
        }
        public bool IsValid(string stringToValidate)
        {
            if (stringToValidate == null)
            {
                return false;
            }
            //testing logic here
            return true;
        }
    }
