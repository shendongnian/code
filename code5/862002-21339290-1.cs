        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //make sure click not on header and column is type of ButtonColumn
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
