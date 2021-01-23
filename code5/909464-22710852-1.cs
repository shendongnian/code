    public partial class YourWindow : Window
    {
        public YourWindow()
        {
            InitializeComponent();
            DataContext = new SomeViewModel();
        }
    }
