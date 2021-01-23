    partial class MainWindow : Window {
        public static readonly DependencyProperty AppSettingsProperty("AppSettings", typeof(AppSettings), typeof(MainWindow), new PropertyMetaData(null));
        public AppSettings AppSettings {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }
        private void ShowSettingsWindowButton_Click(object sender, RoutedEventArgs e ) {
            SettingsWindow settingsWindow = new SettingsWindow();
            Binding appSettingsBinding = new Binding("AppSettings");
            appSettingsBinding.Source = this;
            appSettingsBinding.Path = new PropertyPath( "AppSettings" );
            appSettingsBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding( this, AppSettingsProperty, appSettingsBinding );
            settingsWindow.ShowDialog();
        }
    }
