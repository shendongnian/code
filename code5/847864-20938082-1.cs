    private void  DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    { 
    
    string   constring=System.Configuration.ConfigurationManager.ConnectionStrings["ConnDBForum"].ConnectionString;
    
    
         SqlCommand Cmd = new SqlCommand("Branch_display", connection);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@College_Name", DropDownList2.SelectedValue));
                DataTable dt1 = new DataTable();
                SqlDataAdapter ad1 = new SqlDataAdapter(Cmd);
                ad1.Fill(dt1);
    
                if (dt1.Rows.Count > 0)
                {
    
                    DropDownList1.DataSource = dt1;
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "Name";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                }
                connection.Close();
    }
    
     
