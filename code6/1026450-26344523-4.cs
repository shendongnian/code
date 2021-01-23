    [AttributeUsage(AttributeTargets.Property)]
    public class MinAgeAttribute : ValidationAttribute, IClientValidatable
    {
      public int AgeInYears { get; set; }
      protected override ValidationResult IsValid(object value,
                                                  ValidationContext validationContext)
      {
        // [Similar to before]
      }
      public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
                                                            ModelMetadata metadata,
                                                            ControllerContext context)
      {
        return new[]
        {
          new ModelClientValidationMinAgeRule(ErrorMessage, AgeInYears)
        };
      }
    }
    public class ModelClientValidationMinAgeRule : ModelClientValidationRule
    {
      public ModelClientValidationMinAgeRule(string errorMessage, int ageInYears)
      {
          ErrorMessage = errorMessage;
          // Validation Type and Parameters must be lowercase
          ValidationType = "minage";
          ValidationParameters.Add("ageinyears", ageInYears);
      }
    }
