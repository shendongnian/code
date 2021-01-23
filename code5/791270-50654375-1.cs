        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // once per format
            if (e.ColumnIndex == 0 && e.RowIndex == 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                    if (row != null)
                        row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
