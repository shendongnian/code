    int count =0; // declare in public class
    private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
             dataGridView1.Rows.Add(dataGridView2.SelectedRows.Count); // add rows before entering data inside the new dataGridView.
            }
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                {
                    string value1 = row.Cells[0].Value.ToString();
                    string value2 = row.Cells[1].Value.ToString();
                    dataGridView1.Rows[count].Cells[0].Value = value1;
                    dataGridView1.Rows[count].Cells[1].Value = value2;
                }
            }
         
            count =count + 1;
            dataGridView2.ClearSelection(); // I used this because i have to work with 4 dataGridViews 
    }
