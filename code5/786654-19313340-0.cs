    public partial class MainWindow : Window
    {
        private ICollectionView orderListCVS;
        private List<Order> orders;
        public MainWindow()
        {
            InitializeComponent();
            orders = new List<Order>();
            orderListCVS = CollectionViewSource.GetDefaultView(orders);
        }
        private bool showCompletedFilter(object sender)
        {
            Order order = sender as Order;
            if (order != null)
            {
                return order.Status == Data.Status.Done;
            }
            return false;
        }
        private void showCompletedRB(object sender, RoutedEventArgs e)
        {
            orderListCVS.Filter = showCompletedFilter;
        }
    }
