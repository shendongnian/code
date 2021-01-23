    public partial class MainWindow : Window
    {
        private ICollectionView customers;
        public MainWindow()
        {
            var _customers = new List<Customer>
            {
                // Fill collection
            };
            customers = CollectionViewSource.GetDefaultView(_customers);
            InitializeComponent();
            DataContext = customers;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var c = new Customer { FirstName = "The new", LastName = "The added" };
            // Note that cast is required, otherwise compilation error occurs.
            List<Customer> i = this.customers.SourceCollection as List<Customer>;
            i.Add(c);
        }
    }
