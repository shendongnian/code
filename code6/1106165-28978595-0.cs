    public class Customer
    {
        public void Enable()
        {
            _enabled = true;
    
            DomainEvents.Raise(new CustomerEnabledEvent(_id));
        }
    }
