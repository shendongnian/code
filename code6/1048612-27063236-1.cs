      private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if ( null != row)
            {
                var cell = row.Cells[e.ColumnIndex];
                if ( null != cell)
                {
                    object value = cell.Value;
                    if ( null != value )
                    {
                        // Do your test here in combination with columnindex etc
                    }
                }
            }
        }
