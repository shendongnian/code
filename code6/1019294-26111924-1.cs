    public partial class MainWindow : Window
    {
        public ObservableCollection<Customer> Customers { get; set; }
    
    
        public MainWindow()
        {
            InitializeComponent();
    
            Customers = new ObservableCollection<Customer>();
    
            var conString = "MyConnectionString";
    
            using (var con = new SqlConnection(conString))
            {
                con.Open();
                var sql = "Select Name from Customer";
    
                var cmd = new SqlCommand(sql, con);
    
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Customer
                        {
                            Name = reader[0].ToString()
                        };
    
                        Customers.Add(c);
                    }
                }
            }
        }
    }
    
    public class Customer
    {
        public string Name { get; set; }    
    }
