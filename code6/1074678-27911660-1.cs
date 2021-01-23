    void CellClick(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            string index = cell.Column.DisplayIndex.ToString();
        }
