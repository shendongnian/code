    public class VmFactory
    {
       private static ConcurrentDictionary<int, IClientCustomer> clientCustomers = 
            new ConcurrentDictionary<int, IClientCustomer>();
    
        public IClientCustomer GetCustomerWrapper(ICustomer cust)
        {
           IClientCustomer clientCustomer;
    
           if (!clientCustomers.ContainsKey(cust.ID))
            {
                clientCustomer = new ClientCustomer(cust);
                clientCustomers.TryAdd(cust.ID, clientCustomer);
            }
            else
            {
                clientCustomer = clientCustomers[cust.ID];
            }
    
              return clientCustomer;
       }
    }
