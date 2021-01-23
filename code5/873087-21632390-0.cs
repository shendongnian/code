    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        switch (e.ColumnIndex)
        {
            case 0: //Where the checkboxColumn Index
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = 
                    !(bool) dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                if ((bool)dataGridView1[e.ColumnIndex, e.RowIndex].Value)
                {
                    //Something to do
                }
                break;
        }
    }
