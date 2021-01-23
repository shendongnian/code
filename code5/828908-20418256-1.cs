       private void button1_Click(object sender, EventArgs e)
        {
            int intCell = -1, intRow = -1, count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                intRow++;
            foreach (DataGridViewCell c in row.Cells)
            {
                if (c.Value != null)
                {
                    if (c.Value.ToString() == "0.04")
                    {
                        intCell = +1;
 
                       dataGridView1.Rows[intRow].Cells[intCell].Value = "0";
                       if (intCell == 1)  //Number of your columns
                       {
                           intCell = -1;
                       }
                    }
                }
            }
            }
        }
