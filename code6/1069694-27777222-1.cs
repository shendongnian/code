      public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();          
            ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();
            custdata.Add(new Customer() { ContentData = "content1" });
            custdata.Add(new Customer() { ContentData = "content2" });
            custdata.Add(new Customer() { ContentData = "content3" });
            custdata.Add(new Customer() { ContentData = "content4" });
            custdata.Add(new Customer() { ContentData = "content5" });
            custdata.Add(new Customer() { ContentData = "content6" });
            lst.ItemsSource = custdata;
        }
    }
    public class Customer
    {
        public string ContentData { get; set; }
    }
