    private bool _isLoaded = false;
    public CheckBoxPage()
    {
        InitializeComponent();
        AvailableCheckBox.IsChecked = true;
        _isLoaded = true; // enable the AvailableCheckBox_Checked handler
    }
    void AvailableCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (!_isLoaded) return; // stop here if not loaded yet
        // everything is loaded so let's execute some stuff
        MessageBox.Show("Changed");
    }
