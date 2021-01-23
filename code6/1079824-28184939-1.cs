    using System.ComponentModel.DataAnnotations;
    public class CustomEmailAttribute : ValidationAttribute
    {
        public CustomEmailAttribute()
        {
            this.ErrorMessage = "Error Message Here";
        }
        public override bool IsValid(object value)
        {
            string email = value as string;
            
            // Put validation logic here.
            return valid;
        }
    }
