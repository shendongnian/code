    private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView3.Columns["Select"].Index)//checking for select click
            {
                dataGridView3.CurrentCell.Value = dataGridView3.CurrentCell.FormattedValue.ToString() == "True" ? false : true;
                dataGridView3.RefreshEdit();
            }
        }
