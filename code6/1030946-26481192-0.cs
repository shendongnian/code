    int sum = 0;
    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
    {
    	//for 1st column
    	if (dataGridView1.Rows[i].Cells[0].Value != null && !String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString()))
    		sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
    
    	//for 2nd column
    	if (dataGridView1.Rows[i].Cells[1].Value != null && !String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value.ToString()))
    		sum *= Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
    
    	//for 3rd column
    	if (dataGridView1.Rows[i].Cells[2].Value != null && !String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))
    		sum *= Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
    }
    
    label1.Text = Convert.ToString(sum);
