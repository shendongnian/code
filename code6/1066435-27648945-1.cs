       public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();
            custdata.Add(new Customer() { Email = new Uri("http://stackoverflow.com/") });
            DG1.ItemsSource = custdata;
        }
    }
    public class Customer
    {
        public Uri Email { get; set; }
    }
