    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TimeZonesListBox.ItemsSource = TimeZoneInfo.GetSystemTimeZones();
        }
    
        private void TimeZonesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tz = TimeZonesListBox.SelectedItem as TimeZoneInfo;
            if (tz != null)
                SupportsDaylightCheckBox.IsChecked = tz.SupportsDaylightSavingTime;
        }
    }
