        private void ResultsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var dGrid = (sender as DataGrid);
            if (dGrid == null) return;
            var view = dGrid.ItemsSource as DataView;
            if (view == null) return;
            var table = view.Table;
            e.Column.Header = table.Columns[e.Column.Header as String].Caption;
        }
