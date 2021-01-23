        public MainWindow()
    {
        InitializeComponent();
        second_ComboBox.Visibility = Visibility.Collapsed;
    }
    private void first_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
           first_ComboBox.Visibility = System.Windows.Visibility.Visible;
    }
