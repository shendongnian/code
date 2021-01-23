       // Summary:
    //     Specifies that a data field value is required.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredAttribute : ValidationAttribute
    {
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.RequiredAttribute
        //     class.
        public RequiredAttribute();
        // Summary:
        //     Gets or sets a value that indicates whether an empty string is allowed.
        //
        // Returns:
        //     true if an empty string is allowed; otherwise, false. The default value is
        //     false.
        public bool AllowEmptyStrings { get; set; }
        // Summary:
        //     Checks that the value of the required data field is not empty.
        //
        // Parameters:
        //   value:
        //     The data field value to validate.
        //
        // Returns:
        //     true if validation is successful; otherwise, false.
        //
        // Exceptions:
        //   System.ComponentModel.DataAnnotations.ValidationException:
        //     The data field value was null.
        public override bool IsValid(object value);
    }
