    private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem currentItem = ((System.Windows.Controls.ComboBoxItem)BillStatusCboBox.SelectedItem);
        try
        {
            if (currentItem.Content.Equals("PAID"))
            {
                BillPaidDatedatePicker.IsEnabled = true;
                // BuilderupdateButton.Visibility = Visibility.Visible;
            }
            else
            {
                BillPaidDatedatePicker.IsEnabled = false;
            }
        }
        catch (NullReferenceException ex){ // At here which you can see.
           //I purposely set it to do nothing when catch it.
        }
