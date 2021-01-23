    public class CustomerContractsViewModel:PropertyChangedBase
    {
        public List<Customer> Customers { get; set; }
        public void LoadCustomers(List<Customer> customers)
        {
            Customers = customers;
            OnPropertyChanged("Customers");
        }
    }
