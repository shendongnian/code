      private void button1_Click(object sender, EventArgs e)
        {
            int intCell = 0, intRow = -1, count = 0; //Row count start with -1! --> 0 = first row, 1 = sec. row....
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                intRow++;
            foreach (DataGridViewCell c in row.Cells)
            {
                if (c.Value != null)
                {
                    if (c.Value.ToString() == "0.04")
                    {
                       count ++;
                       dataGridView1.Rows[intRow].Cells[count].Value = "0";
                    }
                }
            }
            }
        }
