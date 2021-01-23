    public class FieldModelValidator : AbstractValidator<FieldViewModel> {
      { 
        public FieldModelValidator()
        {
             RuleFor(x => x.FieldValue ).Must(RangeValidation).When(w => w.Validations.Any(x =>       x.Validations.Contain(2)))
        }
       
        private bool RangeValidation(FieldViewModel field, String value)
        {
                    int val  =int.Parse(value);
                 
                 if(val >= field.MinRange && val <= field.MaxRange )
                 {
                  return true;
                 }
               return false;
        
               
        }
        
            
      }
