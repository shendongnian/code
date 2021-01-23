    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            DropDownList ddlCurrentDropDownList = (DropDownList)sender;
            GridViewRow grdrDropDownRow = ((GridViewRow)ddlCurrentDropDownList.Parent.Parent);
            DropDownList ddList = (DropDownList)grdrDropDownRow.FindControl("ddlstatus");
            statusval = ddList.SelectedValue.ToString();
            Session[statusval] = statusval;    
        }
      protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string rname = (string)row.Cells[1].Text;
           
           
            string ConnectionStringn = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionStringn))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE driver SET status=@status WHERE driverid=@driverid"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@status",statusval);
                    cmd.Parameters.AddWithValue("@driverid",rname);
    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
