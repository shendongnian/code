       private IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row & row.IsSelected) yield return row;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rows = GetDataGridRows(dgv_Students);
            string id; //Sample =>"85-999888-2"
            foreach (DataGridRow dr in rows)
            {
                id = (dr.Item as tbl_student).code_meli;
                MessageBox.Show(id);
            }
        }
