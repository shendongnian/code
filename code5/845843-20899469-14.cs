    public class CustomerViewModel
    {
        private readonly ICollectionView customerView;
     
        public ICollectionView Customers
        {
            get { return this.customerView; }
        }
     
        public CustomerViewModel()
        {
            IList<Customer> customers = GetCustomers();
            this.customerView = CollectionViewSource.GetDefaultView( customers );
        }
    }
