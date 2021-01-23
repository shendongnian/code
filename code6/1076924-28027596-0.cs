    namespace Interface_test.Customers
    {
        public delegate void OpenNewTab(ITabContent uc);
        class CustomerSearchViewModel
        {
            public static event OpenNewTab AddNewCustomerTab = delegate { };
            public CustomerSearchViewModel()
            {
            }
            public ICommand ShowCustomer
            {
                get
                {
                    Customer f = new Customer() { UniqueTabName = "NewTab12", Title = "Customer from search" };
                    return new DelegateCommand(delegate {AddNewCustomerTab(f); });
                }
                
            }
            
        }
    }
