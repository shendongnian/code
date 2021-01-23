        bool IsRadioChecked = false;
        bool IsItemSelected = false;
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            IsRadioChecked = true;
            SetEnable();
        }
        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            if ((sender as ListBox).SelectedItems.Count > 0)
                IsItemSelected = true;
            if ((sender as ListBox).SelectedItems.Count == 0)
                IsItemSelected = false;
            SetEnable();
        }
        public void SetEnable()
        {
            if (IsRadioChecked && IsItemSelected)
                btn.IsEnabled = true;
            else
                btn.IsEnabled = false;
        }
