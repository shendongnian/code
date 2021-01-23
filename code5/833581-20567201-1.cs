    public class RegisterCustomerService : RavenService
    {
        [ValidationFilter]
        public RegisterCustomerResponse Any(RegisterCustomer request)
        {
            RegisterCustomerResponse result = new RegisterCustomerResponse();     
            return result;
        }
    }
