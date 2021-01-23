        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                DataGrid dg = (DataGrid)sender;
                dg.SelectedIndex++;
                dg.CurrentColumn = dg.Columns[0];
                dg.BeginEdit();
                var cell = dg.CurrentColumn.GetCellContent(dg.SelectedItem);
            }
        }
