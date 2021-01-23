    public class RegisterCustomerService : RavenService
    {
        public IValidator<RegisterCustomer> Validator { get; set; }
        public RegisterCustomerResponse Any(RegisterCustomer request)
        {
             ValidationResult result = this.Validator.Validate(instance);
    
            //Result will be serialized into a ValidationErrorException and throw
            if (!result.IsValid)
                throw result.ToException();
            RegisterCustomerResponse result = new RegisterCustomerResponse();     
            return result;
        }
    }
