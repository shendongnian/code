    public partial class MainWindow : Window
    {
        //This is the Collection you will DataBind your ComboBox to
        public ObservableCollection<clsItems> ItemsCollection { get; set; }
        public MainWindow()
        {
            this.ItemsCollection = new ObservableCollection<clsItems>
            {
                new clsItems()
                {
                    ProductName = "Product 1",
                    PurchaseRate = 10
                },
                new clsItems()
                {
                    ProductName = "Product 2",
                    PurchaseRate = 20
                }
            };
            InitializeComponent();
        }
    }
