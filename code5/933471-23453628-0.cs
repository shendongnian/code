    private void button1_Click(object sender, EventArgs e)
    {
        List<int> costs = new List<int>();
    
        //Iterate through each row in the grid
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (null != row && null != row.Cells[1].Value)
            {
               //Add cost value to list
               costs.Add(Convert.ToInt32(row.Cells[1].ToString()));
            }
        }
    
        //get 50% of min value(lowest)
        int result = costs.Min() / 2;
    }
