     public partial class MainWindow : Window
    {
        
        public List<TaxWeek> LTaxWeeks { get; set; }
        public TaxWeek SelectedTaxWeek { get; set; }
        **public DataSet oDS = new DataSet();**
        public MainWindow()
            
        {
            InitializeComponent();
        }
