    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button1.Content = Properties.Settings.Default.ButtonText;
            Closed += SaveSettings;
        }
        private void SaveSettings(object sender, EventArgs e)
        {
            SaveProperties();
        }
        private void SaveProperties()
        {
            Properties.Settings.Default.ButtonText = UserInput.Text;
            Properties.Settings.Default.Save();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
           SaveProperties();
           Button1.Content =  Properties.Settings.Default.ButtonText;
        }
    }
