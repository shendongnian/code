     private void Form5_Load(object sender, EventArgs e)
        {
    		           comboBox1.DataSource = loadddltable();
                        comboBox1.DisplayMember  = "Name";
                        comboBox1.ValueMember  = "ID";
        }
    
    public DataTable loadddl()
            {
                OleDbDataReader obj = null;
                DataTable dt = new DataTable();
                try
                {
                    obj_dbconnection.CommandText = "Select * from TableName";
                    obj = obj_dbconnection.ExecuteReader();
                    if (obj != null)
                    {
                        if (obj.HasRows)
                        {
                            dt.Load(obj);
                        }
                    }
    
                }
                catch (Exception)
                {
    
                }
    
                finally
                {
                    if (obj != null)
                    {
                        obj.Close();
                        obj_dbconnection.Close();
                    }
                }
                return dt;
            }
    
    /*Code for Execute Reader*/
      public OleDbDataReader ExecuteReader()
            {
                OleDbDataReader dr = null;
                try
                {
                    Open();
                    dr = cmd.ExecuteReader();
                }
                catch(Exception)
                { }
                return dr;
            }
    
    /*Code for binding grid data*/
     protected void ddlPaymentSelection_SelectedIndexChanged(object sender, EventArgs e)
            {
    	         dataGridView1.DataSource= getDataForSelectedId(DropdownList1.SelectedValue);
    	     }
