    bool ColorsLoaded = false;
        public Options(MainWindow main)
        {
            InitializeComponent();
            window = main;
            BackgroundColor.SelectedColor = (Color)ColorConverter.ConvertFromString(Settings.Default.Main_Background);
            TopBarBackColor.SelectedColor = (Color)ColorConverter.ConvertFromString(Settings.Default.Main_TopBack);
            ColorsLoaded = true;
        }
        private void Color_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (ColorsLoaded)
            {
                Settings.Default.Main_Background = BackgroundColor.HexadecimalString;
                Settings.Default.Main_TopBack = TopBarBackColor.HexadecimalString;
                Settings.Default.Save();
                window.ColorChange();
            }
        }
