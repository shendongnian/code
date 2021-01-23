    public class ValidationSample
    {
       [RequiredIf("PropertyValidationDependsOn", true)]
       public string PropertyToValidate { get; set; }
       public bool PropertyValidationDependsOn { get; set; }
    }
