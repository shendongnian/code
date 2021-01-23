    private void driverNo_KeyUp(object sender, KeyEventArgs e)
    {
    	// Set all rows.Visible = false in design
    	if (driverNo.Text = "")
    	{
    		foreach (DataGridViewRow row in dataGridView1.Rows)
    		{
    			row.Visible = true;
    		}
    	}
    	else
    	{
    		foreach (DataGridViewRow row in dataGridView1.Rows)
    		{
    			if (row.Cells[1].Value.ToString() == driverNo.Text)
    			{
    				row.Visible = true;
    			}
    		}
    	}
    }
