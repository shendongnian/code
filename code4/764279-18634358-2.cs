    private void frmTableAllotment_Load(object sender, EventArgs e)
    {
       dtTmPkr.Value = System.DateTime.Now;
       LoadComboBox();
    }
    
    private void btnAllocate_Click(object sender, EventArgs e)
    {
    	cmd = new SqlCommand("update  waiterentry2 set status='true'  where name=@name", con);
    	cmd.Parameters.AddWithValue("name", dgvDetails.Rows[i].Cells[0].Value);
    	cmd.ExecuteNonQuery();
    	con.Close();
    	LoadComboBox();
    }
    private void LoadComboBox()
    {
        while(cmbWaiter.Items.Count >0)
             cmbWaiter.Items.RemoveAt(0);
    	cmd = new SqlCommand("Select name from waiterentry2 where status='false'", con);
    	con.Open();
    	dr = cmd.ExecuteReader();
    	while (dr.Read())
    	{
    		cmbWaiter.Items.Add(dr["name"]);
    	}
    
    	dr.Close();
    	cmd = null;
    	con.Close();
    }
