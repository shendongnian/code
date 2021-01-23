    public CheckBoxPage()
    {
        InitializeComponent();
        AvailableCheckBox.IsChecked = true;
        AvailableCheckBox.Checked += AvailableCheckBox_Checked;
    }
    void AvailableCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Changed");
    }
