    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
                DataRow r=dataGridView1.Rows[e.RowIndex];
                Pass_To_Grid2(r);  // Send to Other Grid View..
    }
    
    private void Pass_To_Grid2(DataRow r)
    {
         dataGridView2.Rows.Add(r); /// Must have Same Fields
    }
