    public class NewCustomerProcessor
    {
        private ICustomerDataStorage _storage;
    
        public NewCustomerProcessor(ICustomerDataStorage storage)
        {
            _storage = storage;
        }
    
        public void Process(string name, string address, string email, int age)
        {
            CustomerInfo info = new CustomerInfo(name, address, email, age);
            if(Validate(info))
                _storage.StoreCustomerInfo(info);
        }
        
        private bool Validate(CustomerInfo info)
        {
             //Some validation logic
        }
    }
