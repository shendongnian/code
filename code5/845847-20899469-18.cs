    public class CustomerViewModel
    {
        private readonly ICollectionView customerView;
     
        public ICollectionView Customers
        {
            get { return customerView; }
        }
     
        public CustomerViewModel()
        {
            IList<Customer> customers = GetCustomers();
            customerView = CollectionViewSource.GetDefaultView( customers );
        }
    }
