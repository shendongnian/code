    private void ContractComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
          if(ContractComboBox.SelectedIndex >= 0)
          {
            if (ContractComboBox.SelectedItem.ToString() == "Leasing")
            {
                PriceMonthTextBox.IsEnabled = true;
                PeriodTextBox.IsEnabled = true;
            }
            if (ContractComboBox.SelectedItem.ToString() == "Sale")
            {
                PriceMonthTextBox.IsEnabled = false;
                PeriodTextBox.IsEnabled = false;
            }
          }
    }
