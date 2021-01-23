     protected void gvContactInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    if (e.CommandName.Equals("Update"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                Label lbl = ((Label)gvContactInfo.Rows[RowIndex].FindControl("lblContactidno"));
                DropDownList ddl = ((DropDownList)gvContactInfo.Rows[RowIndex].FindControl("ddlInfoType"));
                TextBox txtinfo = ((TextBox)gvContactInfo.Rows[RowIndex].FindControl("txtValueE"));
                TextBox txtext = ((TextBox)gvContactInfo.Rows[RowIndex].FindControl("txtExt"));
    
                string queryContactInfo = "update tblContactInfo set ContactInfoType='" + ddl.SelectedItem.Text + "',ContactInfo='" + txtinfo.Text + "',Ext='" + txtext.Text + "' where ContactNoID=" + int.Parse(lbl.Text.Trim()) + "";
                Connection = new SqlConnection(ConnString);
                Connection.Open();
                SqlCommand cmd = new SqlCommand(queryContactInfo, Connection);
                cmd.ExecuteNonQuery();
                Connection.Close();
                gvContactInfo.EditIndex = -1;
            }
    }
