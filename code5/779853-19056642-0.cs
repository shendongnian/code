    partial class SettingsWindow : Window {
        public static readonly DependencyProperty AppSettingsProperty("AppSettings", typeof(AppSettings), typeof(SettingsWindow), new PropertyMetaData(null));
        public AppSettings AppSettings {
            get { return (AppSettings) GetValue(AppSettingsProperty); }
            set { SetValue(AppSettingsProperty, value); }
        }
    }
