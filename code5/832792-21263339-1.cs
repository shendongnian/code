        /// <summary>
        /// Select all text in DataGridCell on DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellDoubleClick(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = null;
            TextBox textBox = null;
            cell = sender as DataGridCell;
            if (cell == null)
            {
                return;
            }
            textBox = cell.Content as TextBox;
            if (textBox == null)
            {
                return;
            }
            textBox.SelectAll();
        }
