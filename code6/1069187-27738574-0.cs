    private void Form5_Load(object sender, EventArgs e)
        {
         	   DropdownList1.DataSource = loadddltable();
    
                        DropdownList1.DataTextField = "Name";
                        DropdownList1.DataValueField = "ID";
                        DropdownList1.DataBind();
                        DropdownList1.Items.Insert(0, select);
        }
    
    public DataTable loadddlpublication()
            {
                OleDbDataReader obj = null;
                DataTable dt = new DataTable();
                try
                {
                    obj_dbconnection.CommandText = "Select * from TableName";
                    obj = ExecuteReader();
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
                   GridView1.DataSource= getDataForSelectedId(DropdownList1.SelectedValue);
                    GridView1.DataBind();
                    
        	}
