    public class ModelClientValidationDateRule : ModelClientValidationRule
    {
         public ModelClientValidationDateRule(string errorMessage)
         {
               ErrorMessage = errorMessage;
               ValidationType = "date";
          }
    }
