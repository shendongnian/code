    [DateValidation]
    public System.DateTime Dob { get; set; }
    public class DateValidationAttribute : ValidationAttribute {
      public override bool IsValid(object value) {
         DateTime dateValue;
         var date = DateTime.TryParse(value.toString(), out dateValue);
         // "var dateValue = (DateTime) value;" might work as well, let me know what does.
         return dateValue < DateTime.Now;
      }
    }
