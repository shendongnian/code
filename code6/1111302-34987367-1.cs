        /// <summary>
        /// Skips the 'DataGridCell.Focus' step and goes straight into IsEditing
        /// </summary>
        private void DataGridCell_OnGotFocus(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            cell.IsEditing = true;
        }
        /// <summary>
        /// Skips the 'IsEditing' step and goes straight into IsDropDownOpen
        /// </summary>
        private void Combobox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.IsDropDownOpen = true;
        }
        /// <summary>
        /// Skips the 'IsEditing' step and goes straight into Focus
        /// </summary>
        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Focus();
        }
