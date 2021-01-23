    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            IWorkSpaceViewControl control = tabControl.SelectedContent as IWorkSpaceViewControl;
            control.Refresh();
        }
    }
