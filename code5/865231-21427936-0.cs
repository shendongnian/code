    //check if the value from textBox1 is existed in dataGridView1:
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        {
            if (dataGridView1.Rows[i].Cells[j].Value != null && textBox1.Text == dataGridView1.Rows[i].Cells[j].Value.ToString())
            {
                MessageBox.Show("The value already existed in DataGridView.");
                //you can increase  row["Quantity"] here 
                break;
            }
        }
    }
