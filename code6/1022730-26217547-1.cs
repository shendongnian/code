    protected void ddlSiteID_SelectedIndexChanged(object sender, EventArgs e)
    {
       string selectID = ddlSiteID.SelectedValue;
       using(SqlConnection con = new SqlConnection(@"connectionString"))
       using(SqlCommand cmd = new SqlCommand("SELECT Site_Name,Site_Address FROM tbl_Survey1 where Site_ID=@Site_ID", con))
       {
           con.Open();
           cmd.Parameters.AddWithValue("@Site_ID", selectID);
           cmd.CommandType = CommandType.Text;
           using (SqlDataReader rdr = cmd.ExecuteReader())
           {
              ....
           }
        }
     }
