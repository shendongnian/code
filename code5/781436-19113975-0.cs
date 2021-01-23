    <Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <ListBox ItemsSource={Binding Customers} />
    </Window>
    public class CustomerView
    {
       public CustomerView()
       {
            DataContext = new CustomerViewModel();
       }
    }
     
    public class CustomerViewModel
    {
        private ICollectionView _customerView;
     
        public ICollectionView Customers
        {
            get { return _customerView; }
        }
     
        public CustomerViewModel()
        {
            IList<Customer> customers = GetCustomers();
            _customerView = CollectionViewSource.GetDefaultView(customers);
        }
    }
