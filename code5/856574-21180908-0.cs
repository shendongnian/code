    private void lview_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        // Assuming the property is Employee.FirstName
        tb_firstname.Text = ((Employee)lview.SelectedItem).FirstName;
    }
