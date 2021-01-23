    int num = 0;
    private void dgvLoadData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        bool isChecked = Convert.ToBoolean(dgvLoadData.Rows[dgvLoadData.CurrentCell.RowIndex].Cells[0].Value.ToString());
        if (isChecked)
        {
            num+=1;
        }
        else
        {
            num-=1;
        }
        labelSelectedSum.Text = "Selected Items: " + num;
    }
