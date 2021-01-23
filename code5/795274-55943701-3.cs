        using FluentValidation;
        
        public class CustomerValidator : AbstractValidator<Customer> {
    
        public CustomerValidator() {
            RuleFor(customer => customer.EmailAddress).NotNull().Must(UniqueAddmail);
          }
    
       public bool UniqueAddmail (string EmailAddress)
            {
                return new AnnuaireDbEntities().Wilaya.FirstOrDefault(x => x.Nom == EmailAddress) == null;
            }
        }
    
    
     
