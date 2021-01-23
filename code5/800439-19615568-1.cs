    public partial class YourView : UserControl
    {
        public YourView()
        {
            InitializeComponent();
            DataContext = new YourViewModel();
        }
    }
