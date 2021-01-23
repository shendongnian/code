    public class MyValidator {
        public static ValidationResult ValidateThis(String value, ValidationContext context) {
            var awesome = context.ObjectInstance as Awesome;
            if(awesome == null)
                throw new InstanceNotFoundException(
                    "This validator only works with an Awesome instance.");
            var id = awesome.Id;
            // Do your thing here, like run a dynamic regular expression match
            // based on the value of 'id'.
            return ValidationResult.Success;
        }
    }
