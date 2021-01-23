    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnInitialized(EventArgs e)
        {
            var popup = new PopupWindow();
            popup.ShowDialog();
            base.OnInitialized(e);
        }
    }
