        private void gameDatagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = e.EditingElement as TextBox;
            DataRowView dataRow = (DataRowView)gameDatagrid.SelectedItem;
            int index = gameDatagrid.CurrentCell.Column.DisplayIndex;
            string columnName = gameDatagrid.CurrentCell.Column.Header.ToString();
            string newValue = t.Text;
            int id = (int)dataRow.Row.ItemArray[0];
            string query = "UPDATE table_name SET " + columnName + "=\"" + newValue + "\" WHERE id=" + id;
        }
