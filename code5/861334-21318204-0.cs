        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
            
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("CheckBox1Checked"))
                CheckBox1.Checked = settings["CheckBox1Checked"];
        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings["CheckBox1Checked"] = true;
            settings.Save();
        }
        private void OnUnchecked(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings["CheckBox1Checked"] = false;
            settings.Save();
        }
