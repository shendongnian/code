        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lvpayslip.SelectAll();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lvpayslip.SelectedItems.Clear();
        }
