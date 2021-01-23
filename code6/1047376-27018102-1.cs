    public class IsUnique : ValidationAttribute{
     public override ValidationResult IsValid(object value,
                                             ValidationContext vContext)
    {
        PropertyInfo property = validationContext.ObjectType.GetProperty("Codeno");
        if (property == null)
             return new ValidationResult(string.Format("Property '{0}' is undefined","Codeno"));
         var fieldValue = property.GetValue(validationContext.ObjectInstance, null);
         string codeno= (fieldValue == null ? "" : fieldValue.ToString());
        if (!string.IsNullOrEmpty(codeno))
        {
            MyDBContext db = new MyDBContext();
            Student studentsCodeNo = 
                    db.Students.FirstOrDefault(r => r.codeno== codeno);
            if (studentsCodeNo != null)
            {
                string errorMessage =
                        FormatErrorMessage(vContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
        }
        return ValidationResult.Success;    }}
