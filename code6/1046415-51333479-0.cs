    public static class DataGridHelper
    {
        public static DataGridLength GetColumnWidth(DataGrid obj) => (DataGridLength)obj.GetValue(ColumnWidthProperty);
        public static void SetColumnWidth(DataGrid obj, DataGridLength value) => obj.SetValue(ColumnWidthProperty, value);
        /// <summary> 
        ///   The ColumnWidth attached property sets the Width of all columns.
        /// </summary>
        public static readonly DependencyProperty ColumnWidthProperty =
            DependencyProperty.RegisterAttached("ColumnWidth", typeof(DataGridLength), typeof(DataGridHelper), new PropertyMetadata(ColumnWidthChanged));
        private static void ColumnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;
            var columns = dataGrid.Columns;
            var width = GetColumnWidth(dataGrid);
            dataGrid.Columns.CollectionChanged += (s1, e1) => UpdateColumnWidths(columns, width);
            UpdateColumnWidths(columns, width);
        }
        private static void UpdateColumnWidths(ICollection<DataGridColumn> columns, DataGridLength width)
        {
            foreach (var column in columns) column.Width = width;
        }
    }
