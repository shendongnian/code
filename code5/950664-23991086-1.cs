    public void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    	// Here "i" is the id(Primary key) of the record
            int i = Convert.ToInt32(e.CommandArgument);
    
            if (e.CommandName == "Edit1")
            {
    	   
                // Execute your Database query with where condition for "i" 
    
                while (dr.Read())
                {
    		        DrpCountry.SelectedItem.Value = dr["CountryID"].ToString();
                    DrpState.SelectedItem.Value = dr["StateID"].ToString();
    		        DrpDistrict.SelectedItem.Value = dr["DistrictID"].ToString();
                }
            }
        }
