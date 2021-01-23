    Protected void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnEdit.Visible = true;
            //int i = 0;
            //string defaultvalue = "0";
    		
    		 string qry = "INSERT into tb_externalsystemaccess(User_Id,SystemName,Access_status) VALUES (@v1, @v2, @v3)";
                SqlConnection con = new SqlConnection(str);
    			  for (int i = 0; i < grdExtApp.Rows.Count; i++)
                {
    
                    GridViewRow row = grdExtApp.Rows[i];
    				bool defaultvalue  = ((CheckBox)row.FindControl("AccessExternal")).Checked;
    			    cmd.Parameters.AddWithValue("@v1", TextBox3.Text);    
    				cmd.Parameters.Add("@v2", SqlDbType.Text).Value = Convert.ToString(row.Cells[0].Text);
    				cmd.Parameters.Add("@v3", SqlDbType.Bit).Value =defaultvalue;
                    con.open();
    			    cmd.ExecuteNonQuery();
    				con.Close();
    				con.Dispose();
    				
    			}
            
        }
