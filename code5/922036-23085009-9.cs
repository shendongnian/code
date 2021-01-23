    private void Amount(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == N)//YOUR CHECKBOX COLUM INDEX
            {
                var value = ((DataGridView) sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (value != null)
                {
                    if (Convert.ToBoolean(value) == true)
                        MessageBox.Show("Checked");
                    else
                        MessageBox.Show("Not Checked");
                }
            }
        }
