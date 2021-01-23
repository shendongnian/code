    public partial class MainWindow : Window
    {
        //This is the Collection you will DataBind your ComboBox to
        public ObservableCollection<string> ObservableCollection { get; set; }
        public MainWindow()
        {
            // Initialize the collection with test data.
            this.ObservableCollection = new ObservableCollection<string>
            {
                "string1", "string2"
            };
            InitializeComponent();
        }
    }
