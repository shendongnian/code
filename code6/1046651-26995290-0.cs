    private void myCheckBox_Checked(object sender, RoutedEventArgs e)
    {
         if (((CheckBox)sender).IsChecked == true)
         {
               myTextBox.Focus();
               myTextBox.SelectAll();
         }
         else
         {
               //TODO
         }
    }
