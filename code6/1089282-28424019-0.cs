    private void dataGridView1_CellValueChanged(object sender,DataGridViewCellEventArgs e)
    {
        int col = e.ColumnIndex;
        int row = e.RowIndex;
        double d = Convert.ToDouble(dataGridView1[col, row].Value);
    
        switch (row%2)
        {
            case 0:
               if (d > 5)
                   dataGridView1[col, row].Style.BackColor = Color.Red;
               else
                   dataGridView1[col, row].Style.BackColor = Color.White;
            break;
            case 1:
               if (d > 5)
                   dataGridView1[col, row].Style.BackColor = Color.Red;
               else
                   dataGridView1[col, row].Style.BackColor = Color.Yellow;
            break;
       }
    }
