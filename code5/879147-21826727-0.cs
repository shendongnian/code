      public class FieldModelValidator : AbstractValidator<FieldViewModel> {
       { 
         public FieldModelValidator()
        {
         RuleFor(x => x.FieldValue ).Must(RangeValidation).When(w => w.Validations.Any(x =>       x.Validations.Contain(2)))
        }
    private bool RangeValidation(TextBox textBox, String value)
            {
                int val  =int.TryParse(value);
             
             if(val >= textBox.MinRange && val <= textBox.MinRange )
             {
              return true;
             }
           return false;
    
           
            }
    
        
        }
