        private void RadioButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.IsChecked.GetValueOrDefault())
            {
                radioButton.IsChecked = false;
                e.Handled = true;
            }
        }
