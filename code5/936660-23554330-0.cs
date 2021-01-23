    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
    var container = validationContext.ObjectInstance;
    #region This block of code decompiled from namespace System.ComponentModel.DataAnnotations.ValidationAttribute
    ValidationResult local_0 = ValidationResult.Success;
    if (!this.IsValid(value, container)) // Change to decompiled code here to call our abstract implementation instead of the NotImplemented IsValid(object value) method above
    {
        string[] temp_26;
        if (validationContext.MemberName == null)
            temp_26 = (string[])null;
        else
            temp_26 = new string[1]
                {
                    validationContext.MemberName
                };
        string[] local_1 = temp_26;
        local_0 = new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName), (IEnumerable<string>)local_1);
    }
    return local_0;
    #endregion}
