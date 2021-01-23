    namespace MyMVCApp
    {
        public class Validator
        {
            public static ValidationResult ValidateEndTimeRange(DateTime endTime)
            {
                
                if(endTime.EndDate < DateTime.Now || endTime.EndDate > DateTime.Now.AddDays(1)){
                    return new ValidationResult("Your end date is outside of the acceptable range.");
                }
                return ValidationResult.Success;
            }
        }
    }
