    //check if the value in  same column is repeated dataGridView1:
    
    for (int j = 0; j < dataGridView1.Columns.Count; j++)
    {
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            for (int k = 0; k < dataGridView1.Columns.Count; k++)
            {
                if (dataGridView1.Rows[i].Cells[j].Value.ToString() == dataGridView1.Rows[i].Cells[k].Value.ToString())
                {
                    //you can increase  row["Quantity"] here 
                    break;
                }
            }
                                   
        }
    }
