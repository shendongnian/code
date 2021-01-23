    public class ValidatePriceAttribute: ValidationAttribute
    {
        private double maxVal = 0.0;
        public ValidatePriceAttribute(double maxVal)
        {
           this.maxVal = maxVal;
        }
        protected override ValidationResult IsValid(object value, ValidationContext ctx)
        {
            var obj = ctx.ObjectInstance as Product;
      
            if (obj != null) {
                  if( obj.Price * obj.Quantity > this.maxVal){
                         return new ValidationResult("error message goes here");
                  }
            } 
           return null;
        }
    }
