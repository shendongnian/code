    public partial class MainWindow : Window
    {  
        public CompSetting settings = new CompSetting();
        public MainWindow()
        {   
            InitializeComponent();
        }
        private void click(object sender, MouseButtonEventArgs e)
        {
            var settingsDialog = new SettingDialog(settings);
            settingsDialog.ShowDialog();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (settings.Flag  == 1) 
            {
                LblPortStatus_lable.Content = "chetas";
            }
            else
            {
                LblPortStatus_lable.Content = "rahul";
            }
        }
    }
    // My child window code 
    public partial class SettingDialog : Window
    { 
        private CompSettings settings
        
        public SettingsDialog(CompSettings settings)
        {
            this.settings = settings;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.settings.Flag = 1;
        }
    }
    public class CompSettings
    {
        public int Flag;
    }
