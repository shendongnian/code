        // check if we already added that one
        for (int j = 0; j < dataGridView3.RowCount-1; j++) 
        {
            if (dataGridView3.Rows[j].Cells[1].Value != null && (textBox4.Text == dataGridView3.Rows[j].Cells[4].Value.ToString()))
            {
                MessageBox.Show("Item Already on List!");
                dataGridView3.Rows.Remove(dataGridView3.Rows[n]);
                return;
            }
         }
         
         // lets add it!            
         int n = dataGridView3.Rows.Add();
         dataGridView3.Rows[n].Cells[1].Value = textBox43.Text;
         dataGridView3.Rows[n].Cells[4].Value = textBox4.Text;
         dataGridView3.Rows[n].Cells[2].Value = DateTime.Now.ToShortDateString();
         dataGridView3.Rows[n].Cells[3].Value = dateTimePicker3.Text;
         dataGridView3.FirstDisplayedScrollingRowIndex = n;
         dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
         dataGridView3.Rows[n].Selected = true;
