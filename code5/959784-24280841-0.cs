    public class ApplicationService
    {
        private readonly AccountRepository _accountRepository;
        private readonly BillingRepository _billingRepository;
        public ApplicationService(AccountRepository accountRepository, BillingRepository billingRepository)
        {
            _accountRepository = accountRepository;
            _billingRepository = billingRepository;
        }
        public CreateAccountServiceResponse CreateAccount(AuthenticateApp App, CustomerInfo Customer, ServiceInfo Service, Optional op)
        {
           // SOME VALIDATION CODE   
           //.....................
    
    
    
           // SOME CODE TO SAVE DATA INTO TABLES
           _accountRepository.AddTable_1(objdata_1);
           _accountRepository.AddTable_2(objdata_2);
           _billingRepository.AddTable_3(objdata_3);
        }
    }
