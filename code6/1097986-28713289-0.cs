    interface ICustomerRepository 
    {
        void SaveDisable(Customer customer);
    }
    
    interface ICustomerService 
    {
        void Disable(int customerId);
    }
