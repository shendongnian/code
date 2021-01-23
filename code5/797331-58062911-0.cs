       private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
       {
            int? row = e?.RowIndex;
            int? column = e?.ColumnIndex;
            if (row.HasValue && column.HasValue)
            {
                var dgv = (DataGridView)sender;
                var cell = dgv?.Rows?[row.Value]?.Cells?[column.Value]?.Value;
                if (!string.IsNullOrEmpty(cell?.ToString()))
                {
                    // your code goes here
                };
            };
       }
