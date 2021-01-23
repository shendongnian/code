        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // once per format
            if (e.ColumnIndex == dgv.Columns.Count - 1 && e.RowIndex == dgv.Rows.Count - 1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                    if (row != null)
                        row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
