        public string GetSelectedCellValue()
        {
            DataGridCellInfo cellInfo = MyDataGrid.SelectedCells[0];
            if (cellInfo == null) return null;
            DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
            if (column == null) return null;
            FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, TagProperty, column.Binding);
            return element.Tag.ToString();
        }
