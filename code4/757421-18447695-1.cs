    public partial class DataGridSampleView : Window
    {
        public DataGridSampleView()
        {
            InitializeComponent();
            this.DataContext = new DataGridSampleViewModel();
        }
    }
