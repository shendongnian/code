    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 0) datePicker.IsEnabled = true;
            else datePicker.IsEnabled = false;
        }
