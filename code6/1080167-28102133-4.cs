    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboCustomerIds.DataContext = new Customers();
        }
    }
    /// <summary>
    /// ViewModel
    /// </summary>
    public class Customers
    {
        public List<Customer> LstCustomer { get; set; }
        public Customers()
        {
            LstCustomer = new List<Customer>();
            //get data from DB, here is an example
            for (int i = 1; i < 10; i++)
            {
                Customer c = new Customer();
                c.CustomerId = i;
                c.CustomerName = "name" + i;
                c.CustomerAge = 10 + i;
                LstCustomer.Add(c);
            }
        }
        
    }
    /// <summary>
    /// Model
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
    }
