    <asp:LinkButton ID="linkName" runat="server" Text="Edit" CommandName="displayCustomer"  CommandArgument='<%# Eval("ID")%>' ></asp:LinkButton>
 
    public void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    	    // Here "i" is the id(CommandArgument='<%# Eval("ID")%>') of the record 
            //coming from the link button.
            int i = Convert.ToInt32(e.CommandArgument);
    
            if (e.CommandName == "Edit1")
            {
    	   
                // Execute your Database query with where condition for "i" 
                // and fetch the value in data reader. The Query will be like 
                // Select * from Table_Name where ID = i
                // This will get you the particular record for that ID only
                while (dr.Read())
                {
    		        DrpCountry.SelectedItem.Value = dr["CountryID"].ToString();
                    DrpState.SelectedItem.Value = dr["StateID"].ToString();
    		        DrpDistrict.SelectedItem.Value = dr["DistrictID"].ToString();
                }
            }
        }
