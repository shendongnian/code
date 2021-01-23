    for(int i=0; i<src1.Rows.Count; i++)
    {
        var row1 = src1.Rows[i].ItemArray;
        var row2 = src2.Rows[i].ItemArray;
    
        for(int j = 0; j < row1.Length; j++)
        {
            if (!row1[j].ToString().Equals(row2[j].ToString()))
            {
                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red; 
                dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.Red; 
            }
        }
    }
