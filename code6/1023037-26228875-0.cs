      public MainWindow()
        {
            InitializeComponent();
            second_ComboBox.Visibility = Visibility.Collapsed;
        }
    
        private void first_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = first_ComboBox.SelectedItem as string;
            if (selecteditem != null)
            {
                second_ComboBox.Visibility = Visibility.Visible;
            }
        }
