    public class Customer
    {
        public CustomerEnabledEvent Enable()
        {
            _enabled = true;
    
            return new CustomerEnabledEvent(_id);
        }
    }
